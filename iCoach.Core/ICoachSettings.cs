using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCoach.Core
{
    public interface ICoachSettings
    {
        string FBAppId { get; }
    }

    public class LocalCoachSettings : ICoachSettings
    {
        private string _fbAppId;

        public LocalCoachSettings()
        {
            var rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");

            var fbAppId = rootWebConfig.AppSettings.Settings["fb_app_id"];
            _fbAppId = fbAppId != null ? fbAppId.Value : "-1";
        }

        public string FBAppId { get { return _fbAppId; }}
    }
}
