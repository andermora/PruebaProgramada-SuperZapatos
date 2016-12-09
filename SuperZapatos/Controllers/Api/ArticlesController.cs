using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuperZapatos.Models;

namespace SuperZapatos.Controllers.Api
{
    public class ArticlesController : ApiController
    {
        #region DB CONTEXT

        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        // GET /api/Articles
        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        // GET /api/Articles/1
        public Article GetArticle(int id)
        {
            var article = _context.Articles.SingleOrDefault(c => c.Id == id);

            if (article == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return article;
        }

        // POST /api/Articles
        [HttpPost]
        public Article CreateArticle(Article article)
        {
            // validate request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // add article to db
            _context.Articles.Add(article);
            _context.SaveChanges();

            return article;
        }

        // PUT /api/Articles/1
        [HttpPut]
        public void UpdateArticle(int id, Article article)
        {
            // validate request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // get article from db
            var articleInDb = _context.Articles.SingleOrDefault(c => c.Id == id);

            if (articleInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            articleInDb.Name = article.Name;
            articleInDb.Description = article.Description;
            articleInDb.Price = article.Price;
            articleInDb.TotalInShelf = article.TotalInShelf;
            articleInDb.TotalInVault = article.TotalInVault;
            articleInDb.StoreId = article.StoreId;

            _context.SaveChanges();
        } 

        // DELETE /api/Articles/1
        [HttpDelete]
        public void DeleteArticle(int id)
        {
            // get article from db
            var articleInDb = _context.Articles.SingleOrDefault(c => c.Id == id);

            if (articleInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Articles.Remove(articleInDb);
            _context.SaveChanges();
        }

    }
}
