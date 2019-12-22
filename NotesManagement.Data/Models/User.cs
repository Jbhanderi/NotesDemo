using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Data.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [StringLength(20)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }

    }
}
