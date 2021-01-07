using Reseaarch_Alliances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reseaarch_Alliances.Controllers
{
    public class HomeController : Controller
    {
        ResearchAlliances res = new ResearchAlliances();

        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn","User");
            }
            else
            {
                ViewData["recentArticles"] = res.tblarticles.Where(t => t.CreatedDt.Day == DateTime.Today.Day).ToList();
                ViewData["recentResearches"] = res.tblresearches.Where(t => t.CreatedDt.Day == DateTime.Today.Day).ToList();
                return View();
            }
        }
    }
}