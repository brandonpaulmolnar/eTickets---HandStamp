using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]

    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);
            return View(allEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allEvents.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultOld = allEvents.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allEvents);
        }
        //
        //GET: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var EventDetail = await _service.GetEventByIdAsync(id);
            return View(EventDetail);
        }

        //GET: Events/Create
        public async Task<IActionResult> Create()
        {
            var EventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Locations = new SelectList(EventDropdownsData.Locations, "Id", "Name");
            ViewBag.Sponsors = new SelectList(EventDropdownsData.Sponsors, "Id", "FullName");
            ViewBag.Participants = new SelectList(EventDropdownsData.Participants, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM Event)
        {
            if (!ModelState.IsValid)
            {
                var EventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(EventDropdownsData.Locations, "Id", "Name");
                ViewBag.Sponsors = new SelectList(EventDropdownsData.Sponsors, "Id", "FullName");
                ViewBag.Participants = new SelectList(EventDropdownsData.Participants, "Id", "FullName");

                return View(Event);
            }

            await _service.AddNewEventAsync(Event);
            return RedirectToAction(nameof(Index));
        }

        //GET: Events/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var EventDetails = await _service.GetEventByIdAsync(id);
            if (EventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = EventDetails.Id,
                Name = EventDetails.Name,
                Description = EventDetails.Description,
                AddressLine = EventDetails.AddressLine,
                City = EventDetails.City,
                State = EventDetails.State,
                ZipCode = EventDetails.ZipCode,
                Country = EventDetails.Country,
                Price = EventDetails.Price,
                StartDate = EventDetails.StartDate,
                EndDate = EventDetails.EndDate,
                ImageURL = EventDetails.ImageURL,
                EventCategory = EventDetails.EventCategory,
                LocationId = EventDetails.LocationId,
                SponsorId = EventDetails.SponsorId,
                ParticipantIds = EventDetails.Participants_Events.Select(n => n.ParticipantId).ToList(),
            };

            var EventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Locations = new SelectList(EventDropdownsData.Locations, "Id", "Name");
            ViewBag.Sponsors = new SelectList(EventDropdownsData.Sponsors, "Id", "FullName");
            ViewBag.Participants = new SelectList(EventDropdownsData.Participants, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM Event)
        {
            if (id != Event.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var EventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(EventDropdownsData.Locations, "Id", "Name");
                ViewBag.Sponsors = new SelectList(EventDropdownsData.Sponsors, "Id", "FullName");
                ViewBag.Participants = new SelectList(EventDropdownsData.Participants, "Id", "FullName");

                return View(Event);
            }

            await _service.UpdateEventAsync(Event);
            return RedirectToAction(nameof(Index));
        }

        //Get: Events/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var EventDetails = await _service.GetEventByIdAsync(id);
            if (EventDetails == null) return View("NotFound");
            return View(EventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var EventDetails = await _service.GetEventByIdAsync(id);
            if (EventDetails == null) return View("NotFound");

            await _service.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}