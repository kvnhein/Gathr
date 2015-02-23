using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gatherings.Models.DataGateway;
using Gatherings.Models.Pages;

namespace Gatherings.PopulateModels.Pages
{
    public class PopulateProfilePageModel
    {
        public static ProfilePageModel PopulateProfile()
        {
            ProfilePageModel profilePageModel = new ProfilePageModel();
            //profilePageModel.userInfo = ASPNetUser.GetUserByUserId();

            return profilePageModel;
        }
    }
}