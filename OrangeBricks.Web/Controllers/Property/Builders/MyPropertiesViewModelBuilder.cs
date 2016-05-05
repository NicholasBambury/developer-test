using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyPropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyPropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyPropertiesViewModel Build(string sellerId)
        {
            return new MyPropertiesViewModel
            {
                Properties = _context.Properties
                    .Where(p => p.SellerUserId == sellerId)
                    .Select(p => new PropertyViewModel
                    {
                        Id = p.Id,
                        StreetName = p.StreetName,
                        Description = p.Description,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        PropertyType = p.PropertyType,
                        IsListedForSale = p.IsListedForSale
                    })
                    .ToList()
            };
        }
    }
}