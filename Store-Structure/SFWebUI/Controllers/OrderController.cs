using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFBL;
using SFModels;
using SFWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderBL _rderBL;
        public OrderController(IOrderBL o_rderBL)
        {
            _rderBL = o_rderBL;
        }

        // GET: RestaurantController
        public ActionResult Index(int o_id)
        {
            //We got our list of restaurant from our business layer
            //We converted that Model restaurant into RestaurantVM using Select method
            //Finally we changed it to a List with ToList()
            return View(_rderBL.GetAllOrders(o_id)
                        .Select(rder => new OrderVM(rder))
                        .ToList()
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderVM orderVM)
        {
            if (ModelState.IsValid)
            {
                _rderBL.AddOrder(new Order()
                {
                    CustomerID = orderVM.CustomerID,
                    StoreID = orderVM.StoreID,
                    TotalPrice = orderVM.TotalPrice
                });

                return RedirectToAction(nameof(Index));
            }

            else
            {
                return NotFound();
            }
        }

        //[HttpPost]
        //public IActionResult Select(CustomerVM omerVM)
        //{
            //This if statement will check if the current model that is being passed through is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user 
            //to correct themselves
         //   if (ModelState.IsValid)
         //   {
         //       _omerBL.GetCustomerByID(omerVM.CustomerID);


         ///       return RedirectToAction(nameof(Index));
            //}

            //Will return back to the create view if the user didn't specify the right input
           // return View();
        //}

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
