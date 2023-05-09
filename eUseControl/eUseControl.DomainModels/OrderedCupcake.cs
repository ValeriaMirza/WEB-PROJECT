using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.DomainModels
{
    public class OrderedCupcake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderedCupcakeID { get; set; }

        public int OrderID { get; set; }
        public int CupcakeID { get; set; }

        public int Quantity { get; set; }

     
    }
}
