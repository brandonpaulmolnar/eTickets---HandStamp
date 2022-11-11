using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IEventsService:IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsValues();
        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(NewEventVM data);

        Task DeleteEventAsync(int id);
    }
}
