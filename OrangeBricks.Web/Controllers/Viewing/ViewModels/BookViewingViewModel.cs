using OrangeBricks.Web.Controllers.Property.ViewModels;
using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Viewing.ViewModels
{
    public class BookViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public int PropertyId { get; set; }
        public string BuyerUserId { get; set; }
    }

    public class BookedViewingsViewModel
    {
        public bool HasViewings { get; set; }
        public PropertyViewModel Property { get; set; }
        public IEnumerable<BookViewingViewModel> Viewings { get; set; }
    }

}