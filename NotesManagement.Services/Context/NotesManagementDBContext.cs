using NotesManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Services.Context
{
    public class NotesManagementDBContext : DbContext
    {
        public NotesManagementDBContext() : base("NotesManagementDB")
        {
            Database.SetInitializer(new NotesDBInitializer<NotesManagementDBContext>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }

        private class NotesDBInitializer<T> : DropCreateDatabaseIfModelChanges<NotesManagementDBContext>
        {
            protected override void Seed(NotesManagementDBContext context)
            {
                IList<User> lstDefaultUsers = new List<User>();
                lstDefaultUsers.Add(new User() { UserName = "Jayd", Password = "12345678" });
                lstDefaultUsers.Add(new User() { UserName = "Jaydeep", Password = "12345678" });

                foreach (User user in lstDefaultUsers)
                {
                    context.User.Add(user);
                }

                base.Seed(context);
            }
        }

    }
}
