using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorDataAccessLibrary.Dtos.Notes
{
    public class GetNotesDto
    {
        public int NotesID { get; set; }
        public String NotesText { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
