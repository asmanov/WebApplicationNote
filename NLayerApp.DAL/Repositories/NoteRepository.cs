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
    public class NoteRepository : IRepository<Note>
    {
        private NotesDbContext _db;

        public NoteRepository(NotesDbContext context)
        {
            _db = context;
        }
        public void Create(Note item)
        {
            _db.Notes.Add(item);
        }

        public void Delete(int id)
        {
            Note note = _db.Notes.Find(id);
            if (note != null)
            {
                _db.Notes.Remove(note);
            }
        }

        public IEnumerable<Note> Find(Func<Note, bool> predicate)
        {
            return _db.Notes.Where(predicate).ToList();
        }

        public Note Get(int id)
        {
            return _db.Notes.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _db.Notes;
        }

        public void Update(Note item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
