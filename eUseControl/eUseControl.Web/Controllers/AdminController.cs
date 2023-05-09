using eUseControl.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.ViewModels;

namespace eUseControl.Web.Controllers
{
    public class AdminController : Controller
    {
        IOrdersService os;
        IOrderedCupcakesService ocs;
        public AdminController(IOrdersService os, IOrderedCupcakesService ocs)
        {
            this.os = os; 
            this.ocs = ocs;
        }
        // GET: Admin
        public ActionResult AllOrders()
        {
            List<OrderViewModel> allOrders  = this.os.GetOrders();
            return View(allOrders);
        }
        public ActionResult OrderedCupcakes(int orderId)
        {
            List<OrderedCupcakeViewModel> orderedCupcakes = this.ocs.GetOrderedCupcakesByOrderId(orderId);
            return View(orderedCupcakes);
        }
    }
}