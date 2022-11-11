using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Sponsors = new List<Sponsor>();
            Locations = new List<Location>();
            Participants = new List<Participant>();
        }

        public List<Sponsor> Sponsors { get; set; }
        public List<Location> Locations { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
