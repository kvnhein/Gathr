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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventPageModel model = PopulateEventPageModel.PopulateEvents();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var EventId = Event.CreateEvent();

            return RedirectToAction("Create", "Event", new { Id = EventId });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}