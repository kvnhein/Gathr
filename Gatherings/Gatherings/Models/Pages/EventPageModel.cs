using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models.Pages
{
    public class EventPageModel //: BasePageModel
    {
        public List<EventModel> eventList { get; set; }
        public string bloburl { get; set; }

        public SubmitItem newItem { get; set; }

    }
}