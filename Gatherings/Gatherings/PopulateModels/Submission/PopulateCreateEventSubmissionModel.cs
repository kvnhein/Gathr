using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gatherings.Models.DataGateway;
using Gatherings.Models.Pages;

namespace Gatherings.PopulateModels.Submission
{
    public class PopulateCreateEventSubmissionModel
    {
        public static void CreateEvent(CreateEventPageModel model)
        {
            //We might need a new way to do this
            //if (model.eventSubmission.venue.VenueId == 0)
            //{
            //    model.eventSubmission.venue.VenueId = Event.CreateVenueAndAddress(model.eventSubmission.venue);
            //}

            //Event.CreateEvent();
        }
        
    }
}