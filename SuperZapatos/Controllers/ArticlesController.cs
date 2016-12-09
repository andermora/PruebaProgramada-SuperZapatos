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
    public class ArticlesController : Controller
    {
        #region DB Context

        private ApplicationDbContext _context;

        public ArticlesController()
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
            var viewModel = new ArticleFormViewModel()
            {
                Article = new Article(),
                Stores = _context.Stores.ToList()
            };

            return View("ArticleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Article article)
        {
            // Return to Customer Form if there are validation errors
            if (!ModelState.IsValid)
            {
                var viewModel = new ArticleFormViewModel()
                {
                    Article = article,
                    Stores = _context.Stores.ToList()
                };

                return View("ArticleForm", viewModel);
            }

            if (article.Id == 0)
            {
                _context.Articles.Add(article);
            }
            else
            {
                var articleInDb = _context.Articles.Single(c => c.Id == article.Id);
                articleInDb.Name = article.Name;
                articleInDb.Description = article.Description;
                articleInDb.Price = article.Price;
                articleInDb.TotalInShelf = article.TotalInShelf;
                articleInDb.TotalInVault = article.TotalInVault;
                articleInDb.StoreId = article.StoreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Articles");
        }

        public ActionResult Edit(int id)
        {
            var article = _context.Articles.SingleOrDefault(c => c.Id == id);
            var stores = _context.Stores.ToList();

            if (article == null)
                return HttpNotFound();

            var viewModel = new ArticleFormViewModel()
            {
                Article = article,
                Stores = stores
            };

            return View("ArticleForm", viewModel);

        }
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var article = _context.Articles.SingleOrDefault(c => c.Id == id);

            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }
    }
}