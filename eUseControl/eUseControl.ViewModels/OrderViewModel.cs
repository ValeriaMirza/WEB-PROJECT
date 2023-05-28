using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
       
        public string PostalCode { get; set; }

        [Required]
        
        public string Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderedCupcakeViewModel> OrderedCupcakes { get; set; }
    }

}
