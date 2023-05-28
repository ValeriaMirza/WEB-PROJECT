using eUseControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CheckoutViewModel
{
    public OrderViewModel Order { get; set; }
    public List<CupcakeViewModel> Cupcakes { get; set; }
}

