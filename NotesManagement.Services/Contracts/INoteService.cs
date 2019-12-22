using NotesManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Services.Contracts
{
    public interface INoteService : IRepository<Note>
    {
        IEnumerable<Note> GetUserNotes(int userID);
    }
}
