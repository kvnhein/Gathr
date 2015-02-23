using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models.Pages
{
    public class ProfilePageModel : BasePageModel
    {
        public ef_GetUser_Result userInfo { get; set; }
    }
}