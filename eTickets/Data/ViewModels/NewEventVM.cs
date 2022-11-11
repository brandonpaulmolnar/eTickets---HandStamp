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
    public class NewEventVM
    {
        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Event description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Event image URL")]
        [Required(ErrorMessage = "Event image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Event start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Event end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Event category is required")]
        public EventCategory EventCategory { get; set; }

        //Relationships
        [Display(Name = "Select Participant(s)")]
        [Required(ErrorMessage = "Event Participant(s) is required")]
        public List<int> ParticipantIds { get; set; }

        [Display(Name = "Select a Location")]
        [Required(ErrorMessage = "Event Location is required")]
        public int LocationId { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string AddressLine { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is required")]
        public string ZipCode { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Display(Name = "Select a Sponsor")]
        [Required(ErrorMessage = "Event Sponsor is required")]
        public int SponsorId { get; set; }
    }
}
