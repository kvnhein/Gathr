using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Gatherings.Models;
using Gatherings.Models.Pages;
using Gatherings.Models.DataGateway;

namespace Gatherings.PopulateModels.Pages
{
    public class PopulateEventPageModel
    {
        private static string currentUserID = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId();

        public static EventPageModel PopulateEvents()
        {
            EventPageModel eventPageModel = new EventPageModel();
            eventPageModel.eventList = new List<EventModel>();
            eventPageModel.bloburl = ConfigurationManager.AppSettings["BlobUrl"] + ConfigurationManager.AppSettings["PhotoContainer"];

            var eventHeader = new EventModel();
            var eventItem = new EventItem();

            var allEvents = Event.GetAllEvents();

            Guid oldEvent = new Guid();

            foreach (var item in allEvents)
            { 
                //Map Header Details
                if (item.EventId != oldEvent)
                {
                    oldEvent = item.EventId;

                    eventHeader = new EventModel();
                    var venueData = Event.GetVenueByVenueId(item.VenueId.GetValueOrDefault());

                    eventHeader.EventId = item.EventId;
                    eventHeader.ASPNetUsersId = item.ASPNetUsersId;

                    if (item.ASPNetUsersId == currentUserID)
                    {
                        eventHeader.EventHost = "iHost";
                    }
                    else
                    {
                        eventHeader.EventHost = "theyHost";
                    }
                    eventHeader.Title = item.Title;
                    eventHeader.Description = item.EventDescription;
                    eventHeader.FullName = item.FullName;
                    eventHeader.StartDate = item.StartDate ?? DateTime.Now.AddYears(-500);
                    eventHeader.EndDate = item.EndDate ?? DateTime.Now.AddYears(-500);
                    eventHeader.Image = item.EventImage;

                    eventHeader.venue = new Venue();

                    if (item.VenueId != null)
                    {
                        eventHeader.venue.VenueName = venueData.FirstOrDefault().VenueName;
                        eventHeader.venue.VenueAddress = new Address();
                        eventHeader.venue.VenueAddress.AddressId = venueData.FirstOrDefault().AddressId;
                        eventHeader.venue.VenueAddress.City = venueData.FirstOrDefault().City;
                        eventHeader.venue.VenueAddress.Country = venueData.FirstOrDefault().Country;
                        eventHeader.venue.VenueAddress.PostalCode = venueData.FirstOrDefault().PostalCode;
                        eventHeader.venue.VenueAddress.State = venueData.FirstOrDefault().State;
                        eventHeader.venue.VenueAddress.Street1 = venueData.FirstOrDefault().Street1;
                        eventHeader.venue.VenueAddress.Street2 = venueData.FirstOrDefault().Street2;
                    }

                    eventHeader.EventItems = new List<EventItem>();
                    eventPageModel.eventList.Add(eventHeader);
                }

                //Map Item Details
                eventItem = new EventItem();
                eventItem.ItemId = item.ItemId.GetValueOrDefault();
                eventItem.ItemDescription = item.ItemDescription;
                eventItem.ItemName = item.ItemName;
                eventItem.Price = item.Price;
                eventItem.SponsoredAmount = item.SponsoredAmount;
                eventItem.ItemIsPublic = item.ItemIsPublic;

                eventHeader.EventItems.Add(eventItem);
            }

            return eventPageModel;
        }

        public static EventPageModel PopulateEventDetails(Guid eventId)
        {
            EventPageModel eventPageModel = new EventPageModel();
            eventPageModel.eventList = new List<EventModel>();
            eventPageModel.bloburl = ConfigurationManager.AppSettings["BlobUrl"] + ConfigurationManager.AppSettings["PhotoContainer"];

            var eventHeader = new EventModel();
            var eventItem = new EventItem();


            var allEvents = Event.GetEventByEventId(eventId);

            Guid oldEvent = new Guid();

            foreach (var item in allEvents)
            {
                //Map Header Details
                if (item.EventId != oldEvent)
                {
                    oldEvent = item.EventId;

                    eventHeader = new EventModel();
                    var venueData = Event.GetVenueByVenueId(item.VenueId.GetValueOrDefault());

                    eventHeader.EventId = item.EventId;
                    eventHeader.ASPNetUsersId = item.ASPNetUsersId;
                    eventHeader.Title = item.Title;
                    eventHeader.Description = item.EventDescription;
                    eventHeader.FullName = item.FullName;
                    eventHeader.StartDate = item.StartDate ?? DateTime.Now.AddYears(-500);
                    eventHeader.EndDate = item.EndDate ?? DateTime.Now.AddYears(-500);
                    eventHeader.Image = item.EventImage;

                    eventHeader.venue = new Venue();

                    if (item.VenueId != null)
                    {
                        eventHeader.venue.VenueName = venueData.FirstOrDefault().VenueName;
                        eventHeader.venue.VenueAddress = new Address();
                        eventHeader.venue.VenueAddress.AddressId = venueData.FirstOrDefault().AddressId;
                        eventHeader.venue.VenueAddress.City = venueData.FirstOrDefault().City;
                        eventHeader.venue.VenueAddress.Country = venueData.FirstOrDefault().Country;
                        eventHeader.venue.VenueAddress.PostalCode = venueData.FirstOrDefault().PostalCode;
                        eventHeader.venue.VenueAddress.State = venueData.FirstOrDefault().State;
                        eventHeader.venue.VenueAddress.Street1 = venueData.FirstOrDefault().Street1;
                        eventHeader.venue.VenueAddress.Street2 = venueData.FirstOrDefault().Street2;
                    }

                    eventHeader.EventItems = new List<EventItem>();
                    eventPageModel.eventList.Add(eventHeader);
                }

                //Map Item Details
                eventItem = new EventItem();
                eventItem.ItemId = item.ItemId.GetValueOrDefault();
                eventItem.ItemDescription = item.ItemDescription;
                eventItem.ItemName = item.ItemName;
                eventItem.Price = item.Price;
                eventItem.SponsoredAmount = item.SponsoredAmount;
                eventItem.ItemIsPublic = item.ItemIsPublic;

                eventHeader.EventItems.Add(eventItem);
            }

            return eventPageModel;
        }
    }
}