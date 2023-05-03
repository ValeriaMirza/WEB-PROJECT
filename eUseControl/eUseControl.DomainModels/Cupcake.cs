using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.DomainModels
{
    public class Cupcake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CupcakeID { get; set; }
        public string CupcakeName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
}
