using Authentetication123.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentetication123.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult UserDetails()
        {
            // Retrieve the JSON string from the session
            var userSessionJson = Session["UserSession"] as string;

            

            // Deserialize the JSON string into a SessionInformation object
            var userSession = JsonConvert.DeserializeObject<SessionInformation>(userSessionJson);

            // Pass the data to the view or use it as needed
            return View(userSession);
        }

    }
}