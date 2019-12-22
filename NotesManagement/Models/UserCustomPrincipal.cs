using NotesManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace NotesManagement.Models
{
    public class UserCustomPrincipal : IPrincipal
    {
        private readonly LoginUserIdentity MyIdentity;

        public UserCustomPrincipal(LoginUserIdentity _myIdentity)
        {
            MyIdentity = _myIdentity;
        }
        public IIdentity Identity
        {
            get { return MyIdentity; }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class LoginUserIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public User User { get; set; }

        public LoginUserIdentity(User user)
        {
            Identity = new GenericIdentity(user.UserName);
            User = user;
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public string Name
        {
            get { return Identity.Name; }
        }
    }

}