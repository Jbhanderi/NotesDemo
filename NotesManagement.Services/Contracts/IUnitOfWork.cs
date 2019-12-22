using NotesManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Services.Contracts
{
    public interface IUnitOfWork
    {
        IUserService UserService { get; }

        INoteService NoteService { get; }


        void Commit();
    }
}
