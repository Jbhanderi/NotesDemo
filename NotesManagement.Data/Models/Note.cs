using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Data.Models
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }

        [StringLength(50, ErrorMessage = "Title Should Not Be More Than 50 Characters")]
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }

        public string Body { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
