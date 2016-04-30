using OrangeBricks.Web.Models;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var viewing = new Models.Viewing
            {
                ViewingDateTime = command.ViewingDateTime,
                BuyerUserId = command.BuyerUserId,
                PropertyId = property.Id
            };

            if (property.Viewings == null)
            {
                property.Viewings = new List<Models.Viewing>();
            }

            property.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}