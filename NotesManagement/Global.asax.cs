using NotesManagement.App_Start;
using NotesManagement.Data.Models;
using NotesManagement.Filters;
using NotesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace NotesManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new NotesManagementExceptionFilter());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            UnityConfig.RegisterComponents();

        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authoCookies != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
                JavaScriptSerializer js = new JavaScriptSerializer();
                User user = js.Deserialize<User>(ticket.UserData);
                LoginUserIdentity loginUserIdentity = new LoginUserIdentity(user);
                UserCustomPrincipal userCustomPrincipal = new UserCustomPrincipal(loginUserIdentity);
                HttpContext.Current.User = userCustomPrincipal;
            }
        }
    }
}
