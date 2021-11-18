using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorDataAccessLibrary.Models
{
    public class Notes
    {
        public int NotesID { get; set; }

        [Required]
        [MaxLength(255)]
        public String NotesText { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
