using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Gatherings.Models;
using Gatherings.Models.Pages;
using Gatherings.Models.DataGateway;
using Gatherings.PopulateModels.Pages;
using Gatherings.PopulateModels.Submission;

namespace Gatherings.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Index(Guid id)
        {
            EventPageModel model = PopulateEventPageModel.PopulateEventDetails(id);

            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            EventPageModel model = PopulateEventPageModel.PopulateEventDetails(id);

            return View(model);
        }

        public ActionResult Create(Guid id)
        {
            EventPageModel model = PopulateEventPageModel.PopulateEventDetails(id);

            return View(model);
        }

        public JsonResult UpdateTitle(Guid EventId, string Title) 
        {
            Event.UpdateEventTitle(EventId, Title);

            return null;
        }

        public JsonResult UpdateDescription(Guid EventId, string Description)
        {
            Event.UpdateEventDescription(EventId, Description);

            return null;
        }

        public JsonResult UpdateStartDate(Guid EventId, DateTime StartDate)
        {
            Event.UpdateEventStartDate(EventId, StartDate);

            return null;
        }

        public JsonResult UpdateEndDate(Guid EventId, DateTime EndDate)
        {
            Event.UpdateEventEndDate(EventId, EndDate);

            return null;
        }

        public JsonResult UpdateEndDate(Guid EventId, bool isPublic)
        {
            Event.UpdateEventPublic(EventId, isPublic);

            return null;
        }

        public JsonResult UpdateIsPublic(Guid EventId, bool IsPublic)
        {
            Event.UpdateEventPublic(EventId, IsPublic);

            return null;
        }

        public JsonResult UpdateDelete(Guid EventId, bool IsDelete)
        {
            Event.UpdateEventIsDelete(EventId, IsDelete);

            return null;
        }

        public JsonResult UpdateVenueByVenueId(Guid EventId, Guid VenueId)
        {
            Event.UpdateEventVenueByVenueId(EventId, VenueId);

            return null;
        }

        //public JsonResult UpdateVenueByAddress(Guid EventId, Address addressModel)
        //{
        //    Event.UpdateEventVenueByVenueId(EventId, VenueId);

        //    return null;
        //}

    }
}