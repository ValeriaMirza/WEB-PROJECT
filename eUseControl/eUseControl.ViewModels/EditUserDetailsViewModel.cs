using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.ViewModels
{
    public class EditUserDetailsViewModel
    {
        public int UserID { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string UserName { get; set; }

       
    }
}
