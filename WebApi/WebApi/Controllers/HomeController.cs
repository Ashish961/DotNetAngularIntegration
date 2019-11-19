using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.DAL;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private ClientDb db = new ClientDb();
        public ActionResult Index()
        {            
            
            return View(db.client.ToList());          

           
        }
    }
}
