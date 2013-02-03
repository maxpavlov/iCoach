using System;
using System.Web.Configuration;
using System.Web.Mvc;
using iCoach.Data.Entities;
using iCoach.Models;

namespace iCoach.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly string FbAppId = WebConfigurationManager.AppSettings["fb_app_id"];
        private readonly string VkAppId = WebConfigurationManager.AppSettings["vk_app_id"];
        private readonly string VkAppSecret = WebConfigurationManager.AppSettings["vk_app_secret"];
        private readonly string VkIdentitySecret = WebConfigurationManager.AppSettings["vk_identity_secret"];

        public JsonResult IsAuthenticated()
        {
            return Json(User.Identity.IsAuthenticated.ToString());
        }

        public PartialViewResult RenderLogonView()
        {
            var model = new LoginViewModel();

            if (User.Identity.IsAuthenticated)
            {
                model.ShowAdminFeatures = _roleProvider.ShouldShowUserAnAdminFeatures(User.Identity.Name);

                var visitor = _context.SiteVisitors.Single(vis => vis.UserName == User.Identity.Name);

                UserLogin lastLoginActivity = visitor.Activities.FirstOrDefault(act => act is UserLogin) as UserLogin;

                if (lastLoginActivity != null)
                {
                    foreach (var loginActivity in visitor.Activities.Where(act => act is UserLogin).ToList())
                    {
                        if (lastLoginActivity.CreateTime < loginActivity.CreateTime)
                            lastLoginActivity = loginActivity as UserLogin;
                    }
                }

                if (lastLoginActivity == null || lastLoginActivity.CreateTime.ToLocalTime().Date != DateTime.Today)
                {
                    _brocker.RegisterUserLogonActivity(visitor, this.ActionerIP);
                }

                model.UserScore = visitor.CurrentScore;


                if (User.Identity is FacebookIdentity)
                {
                    var facebookIdentity = User.Identity as FacebookIdentity;
                    if (facebookIdentity != null)
                    {
                        model.DisplayName =
                            facebookIdentity.FacebookName;
                    }
                }
                else if (User.Identity is PutatyIdentity)
                {
                    var putatyIdentity = User.Identity as PutatyIdentity;
                    if (putatyIdentity != null)
                    {
                        model.DisplayName =
                            putatyIdentity.DisplayName;
                    }
                }
                else if (User.Identity is VkIdentity)
                {
                    var vkIdentity = User.Identity as VkIdentity;
                    if (vkIdentity != null)
                    {
                        model.DisplayName =
                            vkIdentity.VkName;
                    }
                }
            }

            model.FbAppId = FbAppId;
            model.VkAppId = VkAppId;
            return PartialView("_LogonView", model);
        }

    }
}
