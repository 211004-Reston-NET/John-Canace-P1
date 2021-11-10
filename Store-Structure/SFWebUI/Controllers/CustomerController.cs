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
    public class CustomerController : Controller
    {
        private ICustomerBL _omerBL;
        public CustomerController(ICustomerBL c_omerBL)
        {
            _omerBL = c_omerBL;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            //We got our list of restaurant from our business layer
            //We converted that Model restaurant into RestaurantVM using Select method
            //Finally we changed it to a List with ToList()
            return View(_omerBL.GetAllCustomers()
                        .Select(omer => new CustomerVM(omer))
                        .ToList()
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM omerVM)
        {
            if (ModelState.IsValid)
            {
                _omerBL.AddCustomer(new Customer()
                {
                    CustomerName = omerVM.CustomerName,
                    CustomerAddress = omerVM.CustomerAddress,
                    CustomerEmail = omerVM.CustomerEmail,
                    CustomerPhoneNumber = omerVM.CustomerPhoneNumber,
                    CustomerID = omerVM.CustomerID
                });

                return RedirectToAction(nameof(Index));
            }

            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Select(CustomerVM omerVM)
        {
            //This if statement will check if the current model that is being passed through is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user 
            //to correct themselves
            if (ModelState.IsValid)
            {
                _omerBL.GetCustomerByID(omerVM.CustomerID);


                return RedirectToAction(nameof(Index));
            }

            //Will return back to the create view if the user didn't specify the right input
            return View();
        }

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