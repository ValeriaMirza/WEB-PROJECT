using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.DomainModels
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int CupcakeID { get; set; }
        public int Quantity { get; set; }
        public int UserID { get; set; }

    }
}
