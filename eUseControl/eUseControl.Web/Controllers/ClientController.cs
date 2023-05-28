using eUseControl.BusinessLogic;
using eUseControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.CustomFilters;

namespace eUseControl.Web.Controllers
{
    public class ClientController : Controller
    {
        IOrdersService os;
        IOrderedCupcakesService ocs;
        public ClientController(IOrdersService os, IOrderedCupcakesService ocs)
        {
            this.os = os;
            this.ocs = ocs;
        }
        [UserAuthorizationFilter]
        public ActionResult MyOrder()
        {
            int uid = (int)Session["CurrentUserID"];
            List<OrderViewModel> myOrder = this.os.GetOrdersByUserID(uid);
            return View(myOrder);
        }
        [UserAuthorizationFilter]
        public ActionResult OrderedCupcakesByUser(int orderId)
        {
            List<OrderedCupcakeViewModel> orderedCupcakes = this.ocs.GetOrderedCupcakesByOrderId(orderId);
            return View(orderedCupcakes);
        }
    }
}