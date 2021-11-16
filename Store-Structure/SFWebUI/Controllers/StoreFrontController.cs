using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFBL;
using SFModels;
using SFWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI.Controllers
{
    public class StoreFrontController : Controller
    {
        private IStoreFrontBL _rontBL;
        private IProductBL _ductBL;
        public StoreFrontController(IStoreFrontBL s_rontBL, IProductBL p_ductBL)
        {
            _rontBL = s_rontBL;
            _ductBL = p_ductBL;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            //We got our list of restaurant from our business layer
            //We converted that Model restaurant into RestaurantVM using Select method
            //Finally we changed it to a List with ToList()
            return View(_rontBL.GetAllStoreFronts()
                        .Select(ront => new StoreFrontVM(ront))
                        .ToList()
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Select(StoreFrontVM rontVM)
        {
            //This if statement will check if the current model that is being passed through is valid
            //If not, the asp-validation-for attribute elements will appear and autofill in the proper feedback for the user 
            //to correct themselves
            if (ModelState.IsValid)
            {
                _rontBL.GetStoreFrontByID(rontVM.StoreFrontId);

                return RedirectToAction(nameof(Index));
            }

            //Will return back to the create view if the user didn't specify the right input
            return View();
        }

        // GET: RestaurantController/Details/5
        [HttpGet]
        public ActionResult Details(int s_id)
        {
            List<Product> prodList = _ductBL.GetStoreFrontInventory(s_id);
            //return View();
            return View(prodList
                .Select(prod => new ProductVM(prod)).ToList());
        }

        [HttpPost]
        public ActionResult Details(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                //l_qua.ProductQuantity += p_howMuchAdded;

                List<Product> prodInInv = _ductBL.GetStoreFrontInventory(product.ProductID);

                //return View(l_qua.ProductQuantity);

                return RedirectToAction(nameof(Index));
            }

            //Will return back to the create view if the user didn't specify the right input
            return View();
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(StoreFront s_id)
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
