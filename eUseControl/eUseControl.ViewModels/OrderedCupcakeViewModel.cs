using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.ViewModels
{
    public class OrderedCupcakeViewModel
    {
        public int CupcakeID { get; set; }
   
        public int Quantity { get; set; }
         public int OrderID { get; set; }
       
    }
}
