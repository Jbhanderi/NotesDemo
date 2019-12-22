using Newtonsoft.Json;
using NotesManagement.Data.Models;
using NotesManagement.Filters;
using NotesManagement.Models;
using NotesManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace NotesManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login", new User());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            User user = _unitOfWork.UserService.GetUserByCredentials(objUser);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string data = js.Serialize(user);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), false, data);
            string encToken = FormsAuthentication.Encrypt(ticket);
            HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
            Response.Cookies.Add(authoCookies);

            LoginUserIdentity loginUserIdentity = new LoginUserIdentity(user);
            UserCustomPrincipal myPrincipal = new UserCustomPrincipal(loginUserIdentity);
            HttpContext.User = myPrincipal;

            return RedirectToAction("Note", "Note");
        }

        [NotesManagementAuthAttribute]
        public ActionResult LogOut()
        {
            HttpContext.Response.Cookies.Clear();
            HttpContext.User = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("");
        }
    }
}