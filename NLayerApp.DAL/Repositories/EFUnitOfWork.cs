using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private NotesDbContext db;
        private NoteRepository notesRepository;

        public IRepository<Note> Notes 
        { 
            get 
            {
                if (notesRepository == null)
                {
                    notesRepository = new NoteRepository(db);
                }
                return notesRepository; 
            }
        }

        public EFUnitOfWork(NotesDbContext notesDbContext)
        {
            db = notesDbContext;
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
