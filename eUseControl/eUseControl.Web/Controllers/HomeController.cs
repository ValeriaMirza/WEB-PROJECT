using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.ViewModels;
using eUseControl.DomainModels;
using Microsoft.AspNet.Identity;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        ICupcakesService cup;
        IOrdersService ord;
        IOrderedCupcakesService ocs;


        public HomeController(ICupcakesService cup,IOrdersService ord, IOrderedCupcakesService ocs)
        {
            this.cup = cup;
            this.ord = ord;
            this.ocs = ocs;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            int uid = (int)Session["CurrentUserID"];
           
            List<CartItemViewModel> cartItems = this.cup.GetCartItems().Where(temp => temp.UserID == uid).ToList();

          
            List<CupcakeViewModel> cupcakes = new List<CupcakeViewModel>();
            foreach (CartItemViewModel ci in cartItems)
            {
                CupcakeViewModel cupcake = this.cup.GetCupcakeById(ci.CupcakeID);
                if (cupcake != null)
                {
                    cupcakes.Add(cupcake);
                }
            }

            return View(cupcakes);
        }
        [HttpPost]
        public ActionResult Checkout(OrderViewModel ovm,OrderedCupcakeViewModel ocvm)
        {
            int uid = (int)Session["CurrentUserID"];
            List<CartItemViewModel> cartItems = this.cup.GetCartItems().Where(temp => temp.UserID == uid).ToList();
            ovm.UserID = uid;
            int orderId = this.ord.CreateOrder(ovm);

         
            foreach (CartItemViewModel ci in cartItems)
            {
                
                ocvm.OrderID = orderId;
                ocvm.CupcakeID=ci.CupcakeID;
                ocvm.Quantity = ci.Quantity;
                this.ocs.InsertOrderedCupcake(ocvm);
                this.DeleteCartItem(ci.CupcakeID);
            }




            return RedirectToAction("Index", "Home");
        }


        public ActionResult Class()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
      
        public ActionResult Shop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Shop(CartItemViewModel rvm)
        {
            // use the uid parameter here
            int uid = (int)Session["CurrentUserID"];
            rvm.UserID = uid;
            int cid = this.cup.InsertCartItem(rvm);

            Session["CartItemID"] = cid;
            Session["CurrentUserID"] = uid;
            Session["CurrentCupcakeID"] = rvm.CupcakeID;
            Session["CurrentQuantity"] = rvm.Quantity;

            return RedirectToAction("ShoppingCart", "Home");
        }



        public ActionResult ShopDetails()
        {
            return View();
        }
      public ActionResult ShoppingCart()
        {
           int uid= (int)Session["CurrentUserID"];
   
    List<CartItemViewModel> cartItems = this.cup.GetCartItems().Where(temp => temp.UserID == uid).ToList();

    List<CupcakeViewModel> cupcakes = new List<CupcakeViewModel>();
    foreach (CartItemViewModel ci in cartItems)
    {
        CupcakeViewModel cupcake = this.cup.GetCupcakeById(ci.CupcakeID);
        if (cupcake != null)
        {
            cupcakes.Add(cupcake);
        }
    }

    return View(cupcakes);
}
        [HttpPost]
        public ActionResult DeleteCartItem(int id)
        {
          
            CartItemViewModel cartItem = this.cup.GetCartItems().FirstOrDefault(temp => temp.CupcakeID == id);

            if (cartItem != null)
            {
                this.cup.DeleteCartItem(cartItem.CartItemID);
            }

          
            return RedirectToAction("ShoppingCart");
        }

       



    }


}