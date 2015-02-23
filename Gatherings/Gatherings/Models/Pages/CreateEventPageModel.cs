using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models.Pages
{
    public class CreateEventPageModel : BasePageModel
    {
        public EventModel eventSubmission { get; set; }
        public List<State> stateList { get; set; }
        public List<ef_GetVenue_Result> venueList { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string StateName { get; set; }
    }
}