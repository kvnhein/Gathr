using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gatherings.Models.DataGateway;
using Gatherings.Models.Pages;

namespace Gatherings.PopulateModels.Pages
{
    public class PopulateCreateEventPageModel
    {
        public static CreateEventPageModel Populate()
        {
            CreateEventPageModel createEventPageModel = new CreateEventPageModel();

            //PopulateBasePageModel.Populate(uploadPhotoPageModelPageModel);

            createEventPageModel.stateList = GetAllStates();
            createEventPageModel.venueList = new List<Models.ef_GetVenue_Result>();

            //We need a new way to do this?
            //createEventPageModel.venueList.Add(new Models.ef_GetVenue_Result
            //{
            //    AddressId = null,
            //    City = "None",
            //    Country = "None",
            //    PostalCode = "None",
            //    VenueId = null,
            //    VenueName = "Create New Venue"
            //});

            createEventPageModel.venueList.AddRange(Event.GetVenueByUserId());

            return createEventPageModel;
        }

        // Collection for state
        public static List<State> GetAllStates()
        {
            List<State> objstate = new List<State>();
            objstate.Add(new State { Value = "0", StateName = "Select State" });
            objstate.Add(new State { Value = "AR", StateName = "AR" });
            objstate.Add(new State { Value = "CA", StateName = "CA" });
            objstate.Add(new State { Value = "CO", StateName = "CO" });
            objstate.Add(new State { Value = "CT", StateName = "CT" });
            objstate.Add(new State { Value = "DE", StateName = "DE" });
            objstate.Add(new State { Value = "DC", StateName = "DC" });
            objstate.Add(new State { Value = "FL", StateName = "FL" });
            objstate.Add(new State { Value = "GA", StateName = "GA" });
            objstate.Add(new State { Value = "HI", StateName = "HI" });
            objstate.Add(new State { Value = "ID", StateName = "ID" });
            objstate.Add(new State { Value = "IL", StateName = "IL" });
            objstate.Add(new State { Value = "IN", StateName = "IN" });
            objstate.Add(new State { Value = "IA", StateName = "IA" });
            objstate.Add(new State { Value = "KS", StateName = "KS" });
            objstate.Add(new State { Value = "KY", StateName = "KY" });
            objstate.Add(new State { Value = "LA", StateName = "LA" });
            objstate.Add(new State { Value = "ME", StateName = "ME" });
            objstate.Add(new State { Value = "MD", StateName = "MD" });
            objstate.Add(new State { Value = "MA", StateName = "MA" });
            objstate.Add(new State { Value = "MI", StateName = "MI" });
            objstate.Add(new State { Value = "MN", StateName = "MN" });
            objstate.Add(new State { Value = "MS", StateName = "MS" });
            objstate.Add(new State { Value = "MO", StateName = "MO" });
            objstate.Add(new State { Value = "MT", StateName = "MT" });
            objstate.Add(new State { Value = "NE", StateName = "NE" });
            objstate.Add(new State { Value = "NV", StateName = "NV" });
            objstate.Add(new State { Value = "NH", StateName = "NH" });
            objstate.Add(new State { Value = "NJ", StateName = "NJ" });
            objstate.Add(new State { Value = "NM", StateName = "NM" });
            objstate.Add(new State { Value = "NY", StateName = "NY" });
            objstate.Add(new State { Value = "NC", StateName = "NC" });
            objstate.Add(new State { Value = "ND", StateName = "ND" });
            objstate.Add(new State { Value = "OH", StateName = "OH" });
            objstate.Add(new State { Value = "OK", StateName = "OK" });
            objstate.Add(new State { Value = "OR", StateName = "OR" });
            objstate.Add(new State { Value = "PA", StateName = "PA" });
            objstate.Add(new State { Value = "RI", StateName = "RI" });
            objstate.Add(new State { Value = "SC", StateName = "SC" });
            objstate.Add(new State { Value = "SD", StateName = "SD" });
            objstate.Add(new State { Value = "TN", StateName = "TN" });
            objstate.Add(new State { Value = "TX", StateName = "TX" });
            objstate.Add(new State { Value = "UT", StateName = "UT" });
            objstate.Add(new State { Value = "VT", StateName = "VT" });
            objstate.Add(new State { Value = "VA", StateName = "VA" });
            objstate.Add(new State { Value = "WA", StateName = "WA" });
            objstate.Add(new State { Value = "WV", StateName = "WV" });
            objstate.Add(new State { Value = "WI", StateName = "WI" });
            objstate.Add(new State { Value = "WY", StateName = "WY" });

            return objstate;
        }
    }
}