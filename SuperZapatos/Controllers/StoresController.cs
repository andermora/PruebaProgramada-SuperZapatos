using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatos.Models;
using SuperZapatos.ViewModels;

namespace SuperZapatos.Controllers
{
    public class StoresController : Controller
    {
        #region DB Context

        private ApplicationDbContext _context;

        public StoresController()
        {
            _context = new ApplicationDbContext();
        }

        // override base dispose method of controller class to dispose of dbcontext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion

        public ActionResult New()
        {
            return View("StoreForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Store store)
        {
            // Return to Customer Form if there are validation errors
            if (!ModelState.IsValid)
            {
                return View("StoreForm", store);
            }

            if (store.Id == null || store.Id == 0)
            {
                _context.Stores.Add(store);
            }
            else
            {
                var storeInDb = _context.Stores.Single(c => c.Id == store.Id);
                storeInDb.Name = store.Name;
                storeInDb.Address = store.Address;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Stores");
        }

        public ActionResult Edit(int id)
        {
            var store = _context.Stores.SingleOrDefault(c => c.Id == id);

            if (store == null)
                return HttpNotFound();

            var viewModel = new StoreFormViewModel()
            {
                Store = store
            };

            return View("StoreForm", store);

        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var store = _context.Stores.SingleOrDefault(c => c.Id == id);

            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }
    }
}