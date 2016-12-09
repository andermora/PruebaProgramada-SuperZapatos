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
    public class StoresController : ApiController
    {
        #region DB CONTEXT

        private ApplicationDbContext _context;

        public StoresController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        // GET /api/stores
        public IEnumerable<Store> GetStores()
        {
            return _context.Stores.ToList();
        }

        // GET /api/stores/1
        public Store GetStore(int id)
        {
            var store = _context.Stores.SingleOrDefault(c => c.Id == id);

            if (store == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return store;
        }

        // POST /api/stores
        [HttpPost]
        public Store CreateStore(Store store)
        {
            // validate request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // add store to db
            _context.Stores.Add(store);
            _context.SaveChanges();

            return store;
        }

        // PUT /api/stores/1
        [HttpPut]
        public void UpdateStore(int id, Store store)
        {
            // validate request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // get store from db
            var storeInDb = _context.Stores.SingleOrDefault(c => c.Id == id);

            if (storeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            storeInDb.Name = store.Name;
            storeInDb.Address = store.Address;

            _context.SaveChanges();
        } 

        // DELETE /api/stores/1
        [HttpDelete]
        public void DeleteStore(int id)
        {
            // get store from db
            var storeInDb = _context.Stores.SingleOrDefault(c => c.Id == id);

            if (storeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Stores.Remove(storeInDb);
            _context.SaveChanges();
        }

    }
}
