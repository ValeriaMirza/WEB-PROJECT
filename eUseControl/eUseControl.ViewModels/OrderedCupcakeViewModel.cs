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
        public string CupcakeName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
