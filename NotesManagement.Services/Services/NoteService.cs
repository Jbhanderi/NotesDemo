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
    public class NoteService : Repository<Note>, INoteService
    {
        public NoteService(NotesManagementDBContext context) : base(context)
        {
        }

        public IEnumerable<Note> GetUserNotes(int userID)
        {
            return Get(c => c.UserID == userID);
        }
    }
}