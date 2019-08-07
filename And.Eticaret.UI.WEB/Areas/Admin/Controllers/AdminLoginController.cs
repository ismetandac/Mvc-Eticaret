using And.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        AndDB db = new AndDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            var data = db.Users.Where(x => x.Email == Email
            && x.Password == Password
            && x.IsActive == true
            && x.IsAdmin == true).ToList();

            if (data.Count == 1)
            {
                //Doğru Giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                //Hatalı Giriş
                return View();
            }

        }
    }
}