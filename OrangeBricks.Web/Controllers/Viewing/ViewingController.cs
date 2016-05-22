using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Viewing.Builders;
using OrangeBricks.Web.Controllers.Viewing.Commands;
using OrangeBricks.Web.Models;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewing
{
    public class ViewingController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(int id)
        {
            var builder = new BookViewingViewModelBuilder(_context);
            var viewModel = builder.Build(id);
            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(BookViewingCommand command)
        {
            var handler = new BookViewingCommandHandler(_context);

            command.BuyerUserId = User.Identity.GetUserId();

            handler.Handle(command);
            return RedirectToAction("Index","Property");
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult ViewingsBooked(int id)
        {
            var builder = new BookedViewingsViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MyViewings()
        {
            var builder = new MyViewingsViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }
    }
}