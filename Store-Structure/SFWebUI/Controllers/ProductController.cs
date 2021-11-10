﻿using Microsoft.AspNetCore.Http;
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
    public class ProductController : Controller
    {
        private IProductBL _ductBL;
        public ProductController(IProductBL p_ductBL)
        {
            _ductBL = p_ductBL;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            //We got our list of restaurant from our business layer
            //We converted that Model restaurant into RestaurantVM using Select method
            //Finally we changed it to a List with ToList()
            return View(_ductBL.GetAllProducts()
                        .Select(duct => new ProductVM(duct))
                        .ToList()
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM ductVM)
        {
            if (ModelState.IsValid)
            {
                _ductBL.AddProduct(new Product()
                {
                    ProductName = ductVM.ProductName,
                    ProductID = ductVM.ProductID,
                    ProductPrice = ductVM.ProductPrice,
                    ProductDescription = ductVM.ProductDescription,
                    ProductCategory = ductVM.ProductCategory,
                    StoreStoreID = ductVM.StoreStoreID,
                    ProductQuantity = ductVM.Quantity
            });

                return RedirectToAction(nameof(Index));
            }

            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Select(ProductVM ductVM)
        {
            //This if statement will check if the current model that is being passed through is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user 
            //to correct themselves
            if (ModelState.IsValid)
            {
                _ductBL.GetProductByID(ductVM.ProductID);


                return RedirectToAction(nameof(Index));
            }

            //Will return back to the create view if the user didn't specify the right input
            return View();
        }

        [HttpPost]
        public IActionResult Select(int s_id)
        {
            //This if statement will check if the current model that is being passed through is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user 
            //to correct themselves
            if (ModelState.IsValid)
            {
                _ductBL.GetStoreFrontInventory(s_id);


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
        public ActionResult Edit(Product l_qua, int p_howMuchAdded)
        {
            if (ModelState.IsValid)
            {
                l_qua.ProductQuantity += p_howMuchAdded;

                return View(l_qua.ProductQuantity);

                //return RedirectToAction(nameof(Index));
            }

            //Will return back to the create view if the user didn't specify the right input
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