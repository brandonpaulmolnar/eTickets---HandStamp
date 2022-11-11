using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Event : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventCategory EventCategory { get; set; }

        //Relationships
        public List<Participant_Event> Participants_Events { get; set; }

        //Location
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public string AddressLine { get; set; }
        [ForeignKey("AddressLine")]
        public string City { get; set; }
        [ForeignKey("City")]
        public string State { get; set; }
        [ForeignKey("State")]
        public string ZipCode { get; set; }
        [ForeignKey("ZipCode")]
        public string Country { get; set; }
        [ForeignKey("Country")]
        
        //Sponsor
        public int SponsorId { get; set; }
        [ForeignKey("SponsorId")]
        public Sponsor Sponsor { get; set; }

    }
}
