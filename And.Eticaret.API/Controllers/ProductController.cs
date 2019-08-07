using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace And.Eticaret.API.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            var db = new AndDB();
            var data = db.Products.Where(x => x.IsActive == true).ToList();
            return data;
        }
        public Product Get(int id)
        {
            var db = new AndDB();
            var data = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return data;
        }
    }
}
