using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace eUseControl.ViewModels
{
    public class AddToCardViewModel
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

    }
}
