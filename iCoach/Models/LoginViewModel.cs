using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCoach.Models
{
    public class LoginViewModel
    {
        public string DisplayName { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool ShowAdminFeatures { get; set; }
        public string VkAppId { get; set; }
        public string FbAppId { get; set; }
        public int UserScore { get; set; }
    }
}