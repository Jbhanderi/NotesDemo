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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;

        private readonly object _disposeLock = new object();

        private NotesManagementDBContext _dbContext;

        private UserService _userService;
        private NoteService _noteService;


        public UnitOfWork(NotesManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserService UserService
        {
            get
            {
                return _userService ??
                    (_userService = new UserService(_dbContext));
            }
        }

        public INoteService NoteService
        {
            get
            {
                return _noteService ??
                    (_noteService = new NoteService(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _dbContext.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
    }
}
