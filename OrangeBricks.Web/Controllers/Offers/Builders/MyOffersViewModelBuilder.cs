using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Offers.ViewModels;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            var myOffers = _context.Offers
                .Where(p => p.BuyerUserId == buyerId).ToList<Offer>();

            return new MyOffersViewModel
            {   
                MyOffers = myOffers.Select(x => new MyOfferViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == OfferStatus.Pending,
                    Status = x.Status.ToString(),
                    BuyerUserId = x.BuyerUserId,
                    StreetName = GetPropertyStreetName(x.PropertyId)
                }),

                
            };
        }

        private string GetPropertyStreetName(int propertyId)
        {
            var property = _context.Properties
                .Where(p => p.Id == propertyId)
                .SingleOrDefault();

            return property.StreetName;
        }
    }
}