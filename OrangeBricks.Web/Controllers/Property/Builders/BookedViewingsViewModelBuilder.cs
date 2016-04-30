using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class BookedViewingsViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookedViewingsViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookedViewingsViewModel Build(int id)
        {
            var viewings = _context.Viewings.Where(v => v.PropertyId == id).ToList();

            return new BookedViewingsViewModel
            {
                HasViewings = viewings.Any(),
                Property = BuildPropertyViewModel(id),
                Viewings = BuildBookViewing(viewings)
            };
        }

        private IEnumerable<BookViewingViewModel> BuildBookViewing(List<Viewing> viewings)
        {
            List<BookViewingViewModel> bookViewings = new List<BookViewingViewModel>();

            foreach (var viewing in viewings)
            {
                bookViewings.Add(new BookViewingViewModel
                {
                    BuyerUserId = viewing.BuyerUserId,
                    PropertyId = viewing.PropertyId,
                    ViewingDateTime = viewing.ViewingDateTime
                });
            }

            return bookViewings;
        }

        private PropertyViewModel BuildPropertyViewModel(int id)
        {
            var property = _context.Properties.Find(id);

            return new PropertyViewModel
            {
                Description = property.Description,
                Id = property.Id,
                IsListedForSale = property.IsListedForSale,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName
            };
        }
    }
}