using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteBody { get; set; }
        public DateTime Created { get; set; }

        public Note()
        {
            Created = DateTime.Now;
        }
    }
}
