using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace And.Eticaret.UI.WEB
{
    public class AndControllerBase : Controller
    {
        /// <summary>
        /// Kullanıcı Login Kontrolü
        /// </summary>
        public bool IsLogin { get; private set; }
        /// <summary>
        /// Giriş Yapmış kişinin IDsi
        /// </summary>
        public int LoginUserID { get; private set; }
        /// <summary>
        /// Login User Entity
        /// </summary>
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUserID"]
            // Session["LoginUser"]
            if (requestContext.HttpContext.Session["LoginUserID"] != null)
            {
                //Kullnıcı Giriş Yapmış
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }
            base.Initialize(requestContext);
        }
    }
}