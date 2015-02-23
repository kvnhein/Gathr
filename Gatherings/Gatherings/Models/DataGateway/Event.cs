using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
//using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Blob;

//using ImageResizer;

using Gatherings.Models.Pages;

namespace Gatherings.Models.DataGateway
{
    public class Event
    {
        private static string currentUserID = HttpContext.Current.User.Identity.GetUserId();

        // Get
        public static List<ef_GetEvent_Result> GetAllEvents()
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetEvent(null, null).ToList();
            }
        }
        public static List<ef_GetEvent_Result> GetEventByThisUser()
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetEvent(null, currentUserID).ToList();
            }
        }
        public static List<ef_GetEvent_Result> GetEventByEventId(Guid eventID)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetEvent(eventID, null).ToList();
            }
        }
        public static List<ef_GetVenue_Result> GetVenueByVenueId(Guid venueID)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetVenue(null, venueID).ToList();
            }
        }
        public static List<ef_GetVenue_Result> GetVenueByUserId()
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetVenue(currentUserID, null).ToList();
            }
        }
        public static List<ef_GetVenue_Result> GetAllVenues()
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetVenue(null, null).ToList();
            }
        }
        public static List<ef_GetItem_Result> GetItemById(Guid itemId)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                return _db.ef_GetItem(itemId).ToList();
            }
        }

        // Create
        public static Guid CreateEvent()
        {
            Guid newID = Guid.NewGuid();

            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_CreateEvent(newID, currentUserID, null, null, null, null, null, null, false);
            }

            return newID;
        }

        public static Guid CreateItem(SubmitItem model)
        {
            Guid newID = Guid.NewGuid();
            
            model.baseNewItem.ItemIsPublic = true;
            
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_CreateItem(newID, model.EventIdForSubmit, null, model.baseNewItem.ItemName, model.baseNewItem.ItemDescription, model.baseNewItem.Price, model.baseNewItem.ItemIsPublic, currentUserID);
            }

            return newID;
        }

        //public static int CreateSponsorship(PurchasePageModel model)
        //{
        //    int newID;

        //    model.eventItem.ItemIsPublic = true;

        //    using (GatheringsEntities _db = new GatheringsEntities())
        //    {
        //        var sponsorID = _db.ef_CreateSponsorship(model.eventItem.ItemId, currentUserID, model.SponsorAmount, model.eventItem.ItemIsPublic).FirstOrDefault().Value;

        //        newID = Convert.ToInt32(sponsorID);
        //    }

        //    return newID;
        //}

        public static Guid CreateVenueAndAddress(Venue venue)
        {
            Guid newID = Guid.NewGuid();

            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_CreateVenue(newID, currentUserID, venue.VenueName, null, venue.VenueAddress.Street1, venue.VenueAddress.Street2, null, null, venue.VenueAddress.City, venue.VenueAddress.State, venue.VenueAddress.PostalCode, venue.VenueAddress.Country);
            }

            return newID;
        }

        public static string UploadPhoto(HttpPostedFileBase file)
        {
            //string newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName); //New Filename of Guid
            //string origFileName = newFileName.Replace(Path.GetExtension(file.FileName), "_original" + Path.GetExtension(file.FileName));
            //string thumbFileName = newFileName.Replace(Path.GetExtension(file.FileName), "_thumb" + Path.GetExtension(file.FileName));
            //string bannerFileName = newFileName.Replace(Path.GetExtension(file.FileName), "_banner" + Path.GetExtension(file.FileName));

            //MemoryStream newfile = new MemoryStream();
            //file.InputStream.CopyTo(newfile);
            //file.InputStream.Seek(0, SeekOrigin.Begin);

            //StorageCredentials sc = new StorageCredentials(WebConfigurationManager.AppSettings["StorageName"], WebConfigurationManager.AppSettings["AccessKey"]);
            //CloudStorageAccount storageAccount = new CloudStorageAccount(sc, false);
            //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            //CloudBlobContainer container = blobClient.GetContainerReference("photos");
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference(origFileName);
            //blockBlob.UploadFromStream(file.InputStream);

            //blockBlob = container.GetBlockBlobReference(bannerFileName);

            //ImageResizer.Instructions instrBanner = new Instructions();
            //instrBanner.Scale = ScaleMode.Both;
            //instrBanner.Width = 1170;
            //instrBanner.Height = 350;
            //instrBanner.Mode = FitMode.Crop;
            
            //using (var msBanner = new MemoryStream())
            //{
            //    newfile.Seek(0, SeekOrigin.Begin);

            //    ImageResizer.ImageJob iBanner = new ImageResizer.ImageJob(newfile,
            //        msBanner, instrBanner);

            //    iBanner.Build();

            //    blockBlob.Properties.ContentType = file.ContentType;

            //    msBanner.Seek(0, SeekOrigin.Begin); //Set the memory stream to the beginning
            //    blockBlob.UploadFromStream(msBanner);
            //}

            //blockBlob = container.GetBlockBlobReference(newFileName);

            //ImageResizer.Instructions instr = new Instructions();
            //instr.Scale = ScaleMode.Both;
            //instr.Width = 1024;
            //instr.Height = 680;
            //instr.Mode = FitMode.Max;

            //using (var ms = new MemoryStream())
            //{
            //    file.InputStream.Seek(0, SeekOrigin.Begin); //Set the memory stream to the beginning

            //    ImageResizer.ImageJob i = new ImageResizer.ImageJob(file.InputStream,
            //            ms, instr);

            //    i.Build();

            //    blockBlob.Properties.ContentType = file.ContentType;

            //    ms.Seek(0, SeekOrigin.Begin); //Set the memory stream to the beginning
            //    blockBlob.UploadFromStream(ms);

            //    //Thumbnail Upload
            //    blockBlob = container.GetBlockBlobReference(thumbFileName);

            //    ImageResizer.Instructions newInstr = new Instructions();
            //    newInstr.Scale = ScaleMode.Both;
            //    newInstr.Width = 640;
            //    newInstr.Height = 426;
            //    newInstr.Mode = FitMode.Crop;

            //    using (var ms2 = new MemoryStream())
            //    {
            //        ms.Seek(0, SeekOrigin.Begin); //Set the memory stream to the beginning

            //        ImageResizer.ImageJob i2 = new ImageResizer.ImageJob(ms,
            //                ms2, newInstr);

            //        i2.Build();

            //        blockBlob.Properties.ContentType = file.ContentType;

            //        ms2.Seek(0, SeekOrigin.Begin); //Set the memory stream to the beginning
            //        blockBlob.UploadFromStream(ms2);
            //    }
            //}

            //return newFileName;
            return null;
        }

        // Update
        public static void UpdateEventTitle(Guid EventId, string Title)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, Title, null, null, null, null, null, null, null);
            }
        }

        public static void UpdateEventDescription(Guid EventId, string Description)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, Description, null, null, null, null, null, null);
            }
        }

        public static void UpdateEventImage(Guid EventId, string Image)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, Image, null, null, null, null, null);
            }
        }

        public static void UpdateEventStartDate(Guid EventId, DateTime StartDate)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, null, StartDate, null, null, null, null);
            }
        }

        public static void UpdateEventEndDate(Guid EventId, DateTime EndDate)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, null, null, EndDate, null, null, null);
            }
        }

        public static void UpdateEventVenueByVenueId(Guid EventId, Guid VenueId)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, null, null, null, VenueId, null, null);
            }
        }

        public static void UpdateEventPublic(Guid EventId, bool isPublic)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, null, null, null, null, isPublic, null);
            }
        }

        public static void UpdateEventIsDelete(Guid EventId, bool IsDelete)
        {
            using (GatheringsEntities _db = new GatheringsEntities())
            {
                _db.ef_UpdateEvent(EventId, null, null, null, null, null, null, null, IsDelete);
            }
        }

    }
}