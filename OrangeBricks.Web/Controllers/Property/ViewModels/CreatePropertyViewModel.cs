using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class CreatePropertyViewModel
    {
        [Required]
        [Display(Name = "Property type" )]
        public string PropertyType { get; set; }

        [Required]
        [Display(Name = "Street name")]
        public string StreetName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of bedrooms")]
        public int NumberOfBedrooms { get; set; }

        public IEnumerable<SelectListItem> PossiblePropertyTypes { get; set; }
    }
}