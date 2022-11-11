using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                AddressLine = data.AddressLine,
                City = data.City,
                State = data.State,
                ZipCode = data.ZipCode,
                Country = data.Country,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                LocationId = data.LocationId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EventCategory = data.EventCategory,
                SponsorId = data.SponsorId
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            //Add Event Participants
            foreach (var ParticipantId in data.ParticipantIds)
            {
                var newParticipantEvent = new Participant_Event()
                {
                    EventId = newEvent.Id,
                    ParticipantId = ParticipantId
                };
                await _context.Participants_Events.AddAsync(newParticipantEvent);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var EventDetails = await _context.Events
                .Include(c => c.Location)
                .Include(p => p.Sponsor)
                .Include(am => am.Participants_Events).ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return EventDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsValues()
        {
            var response = new NewEventDropdownsVM()
            {
                Participants = await _context.Participants.OrderBy(n => n.FullName).ToListAsync(),
                Locations = await _context.Locations.OrderBy(n => n.Name).ToListAsync(),
                Sponsors = await _context.Sponsors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task DeleteEventAsync(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(n => n.Id == id);
            _context.Events.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbEvent != null)
            {
                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.Price = data.Price;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.LocationId = data.LocationId;
                dbEvent.AddressLine = data.AddressLine;
                dbEvent.City = data.City;
                dbEvent.State = data.State;
                dbEvent.ZipCode = data.ZipCode;
                dbEvent.Country = data.Country;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.EventCategory = data.EventCategory;
                dbEvent.SponsorId = data.SponsorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing Participants
            var existingParticipantsDb = _context.Participants_Events.Where(n => n.EventId == data.Id).ToList();
            _context.Participants_Events.RemoveRange(existingParticipantsDb);
            await _context.SaveChangesAsync();

            //Add Event Participants
            foreach (var ParticipantId in data.ParticipantIds)
            {
                var newParticipantEvent = new Participant_Event()
                {
                    EventId = data.Id,
                    ParticipantId = ParticipantId
                };
                await _context.Participants_Events.AddAsync(newParticipantEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
