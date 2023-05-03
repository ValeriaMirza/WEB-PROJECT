using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.DomainModels
{
    public class OrderedCupcake
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        public int CupcakeID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("CupcakeID")]
        public virtual Cupcake Cupcake { get; set; }
    }
}
