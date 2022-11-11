using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Location : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location Logo")]
        [Required(ErrorMessage = "Location logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Location description is required")]
        public string Description { get; set; }
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

        //Relationships
        public List<Event> Events { get; set; }
    }
}
