using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models
{
    public class EventModel
    {
        public Guid EventId { get; set; }
        public string ASPNetUsersId { get; set; }
        public string EventHost { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase imageFile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Venue venue { get; set; }
        public bool isPublic { get; set; }
        public bool IsDeleted { get; set; }
        public List<EventItem> EventItems { get; set; }
    }

    public class EventItem
    {
        public Guid ItemId { get; set; }
        public Guid EventId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> SponsoredAmount { get; set; }
        public bool ItemIsPublic { get; set; }
    }

    public class Venue
    {
        public Guid VenueId { get; set; }
        public Address VenueAddress { get; set; }
        public string VenueName { get; set; }
    }

    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Street4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class SubmitItem
    {
        public Guid EventIdForSubmit { get; set; }
        public EventItem baseNewItem { get; set; }
    }
}