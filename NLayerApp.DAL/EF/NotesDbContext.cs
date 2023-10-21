using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
