using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MyViewingsViewModel
    {
        public bool HasViewings { get; set; }
        public IEnumerable<BookViewingViewModel> Viewings { get; set; }
    }
}