﻿using System;
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
    public class AdminController : Controller
    {
        IOrdersService os;
        IOrderedCupcakesService ocs;
        IUsersService us;
        public AdminController(IOrdersService os, IOrderedCupcakesService ocs, IUsersService us)
        {
            this.os = os; 
            this.ocs = ocs;
            this.us = us;
        }
       
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
        public ActionResult ShowUsers()
        {
            List<UserViewModel> users = this.us.GetUsers();
            return View(users);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {

            this.us.DeleteUser(id);


            return RedirectToAction("YouDeletedTheUser", "Admin");

        }
        public ActionResult YouDeletedTheUser()
        {
            return View();
        }
    }
}