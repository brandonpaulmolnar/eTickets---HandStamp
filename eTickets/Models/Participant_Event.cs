using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Participant_Event
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
