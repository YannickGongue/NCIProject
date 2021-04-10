using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCIProject.Controllers
{
    public class HomeController : Controller
    {
      // GET: Home
      public ActionResult Index()
      {
         //if (Session["User_ID"] != null)
         //{
         //   return Redirect("/Home/Index");
         //}
         //else
         //{
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

      public ActionResult Submission()
      {
         ViewBag.Message = "Your Submission page.";
         return View();
      }
   }
}