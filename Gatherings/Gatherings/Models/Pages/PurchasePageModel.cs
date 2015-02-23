using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models.Pages
{
    public class PurchasePageModel : BasePageModel
    {
        public EventItem eventItem { get; set; }
        public decimal SponsorAmount { get; set; }
    }
}