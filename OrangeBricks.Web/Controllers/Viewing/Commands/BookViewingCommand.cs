using System;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{
    public class BookViewingCommand
    {
        public int PropertyId { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public string BuyerUserId { get; set; }
    }
}