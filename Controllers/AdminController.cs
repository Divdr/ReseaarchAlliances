using Reseaarch_Alliances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reseaarch_Alliances.Controllers
{
    public class AdminController : Controller
    {

        ResearchAlliances res = new ResearchAlliances();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else { 
                ViewBag.users = res.tblusers.ToList().Count();
                ViewBag.articles = res.tblarticles.ToList().Count();
                ViewBag.researches = res.tblresearches.ToList().Count();
                ViewBag.category = res.tblcategories.ToList().Count();
                return View();
            }
        }

        public ActionResult doLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult doLogIn(tbladmin adm)
        {
            tbladmin _adm = res.tbladmin.Where(t => t.UserName.Equals(adm.UserName) && t.Password.Equals(adm.Password)).SingleOrDefault();
            if (adm!=null)
            {
                Session["AdminID"] = _adm.AdminID;
                Session["AdminName"] = _adm.UserName;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("doLogIn");
            }
            
        }

        public ActionResult States()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblstates.ToList());
            }
        }

        public ActionResult CityByState(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblcities.Where(t => t.StateID == id).ToList());
            }
        }

        public ActionResult Category()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblcategories.ToList());
            }
        }

        public ActionResult AddCategory()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddCategory(tblcategory cat)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                res.tblcategories.Add(cat);
                res.SaveChanges();
                return RedirectToAction("Category");
            }
        }

        public ActionResult SubCategoryByCat(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblsubcategories.Where(t => t.CategoryID == id).ToList());
            }
        }

        public ActionResult AddSubCategory(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                tblsubcategory _subcat = new tblsubcategory();
                _subcat.CategoryID = id;
                ViewData.Model = _subcat;
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddSubCategory(tblsubcategory scat)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                res.tblsubcategories.Add(scat);
                res.SaveChanges();
                return RedirectToAction("SubCategoryByCat", new { id = scat.CategoryID });
            }
        }

        public ActionResult Users()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblusers.ToList());
            }
        }

        public ActionResult Articles()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblarticles.ToList());
            }
        }

        public ActionResult Researches()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("doLogIn");
            }
            else
            {
                return View(res.tblresearches.ToList());
            }
        }

        public ActionResult doLogout()
        {
            Session.Abandon();
            return RedirectToAction("doLogIn");
        }

    }
}