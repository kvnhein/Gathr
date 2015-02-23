using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gatherings.Models.Pages
{
    public class BasePageModel
    {
        public LoginViewModel loginView { get; set; }
        public ExternalLoginConfirmationViewModel externalModel { get; set; }
    }
}