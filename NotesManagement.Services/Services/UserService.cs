using NotesManagement.Data.Models;
using NotesManagement.Services.Context;
using NotesManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Services.Services
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(NotesManagementDBContext context) : base(context)
        {
        }

        public User GetUserByCredentials(User user)
        {
            return Get(c => c.UserName.Equals(user.UserName) && c.Password.Equals(user.Password)).FirstOrDefault();
        }
    }
}
