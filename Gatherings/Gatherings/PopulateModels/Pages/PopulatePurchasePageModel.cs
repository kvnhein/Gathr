using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using Gatherings.Models;
using Gatherings.Models.Pages;
using Gatherings.Models.DataGateway;

namespace Gatherings.PopulateModels.Pages
{
    public class PopulatePurchasePageModel
    {
        public static PurchasePageModel PopulatePurchasePage(Guid itemId)
        {
            PurchasePageModel purchasePageModel = new PurchasePageModel();
            purchasePageModel.eventItem = new EventItem();

            var returnedItem = Event.GetItemById(itemId).FirstOrDefault();

            //Map Item
            purchasePageModel.eventItem.ItemId = itemId;
            purchasePageModel.eventItem.EventId = returnedItem.EventId;
            purchasePageModel.eventItem.ItemName = returnedItem.Name;
            purchasePageModel.eventItem.ItemDescription = returnedItem.Description;
            purchasePageModel.eventItem.Price = returnedItem.Price;
            purchasePageModel.eventItem.SponsoredAmount = returnedItem.SponsoredAmount;

            return purchasePageModel;
        }

    }
}