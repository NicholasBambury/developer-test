using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class MyViewingsViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyViewingsViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyViewingsViewModel Build(string buyerUserId)
        {
            var viewings = _context.Viewings.Where(v => v.BuyerUserId == buyerUserId).ToList();

            return new MyViewingsViewModel
            {
                HasViewings = viewings.Any(),
                Viewings = CreateViewingViewModel(viewings)
            };
        }

        private IEnumerable<BookViewingViewModel> CreateViewingViewModel(List<Models.Viewing> viewings)
        {
            List<BookViewingViewModel> bookViewings = new List<BookViewingViewModel>();

            foreach (var viewing in viewings)
            {
                var property = _context.Properties.Where(p => p.Id == viewing.PropertyId).SingleOrDefault();

                bookViewings.Add(new BookViewingViewModel
                {
                    BuyerUserId = viewing.BuyerUserId,
                    PropertyId = viewing.PropertyId,
                    ViewingDateTime = viewing.ViewingDateTime,
                    StreetName = property.StreetName,
                    PropertyType = property.PropertyType
                });
            }
            return bookViewings;
        }
    }
}