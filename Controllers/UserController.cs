using Reseaarch_Alliances.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reseaarch_Alliances.Controllers
{
    public class UserController : Controller
    {
        ResearchAlliances res = new ResearchAlliances();

        // GET: User
        public ActionResult Index(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblusers.Where(t => t.UserID == id).SingleOrDefault());
            }
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(tbluser u, HttpPostedFileBase ProfilePic)
        {
            var fileName = Path.GetFileName(ProfilePic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Images/User"), fileName);
            ProfilePic.SaveAs(path);
            u.ProfilePic = fileName;
            int cityid =Convert.ToInt32( Request["CityID"]);
            byte gen = Convert.ToByte( Request["Gender"]);

            u.CityID = cityid;
            u.Gender = gen;
            res.tblusers.Add(u);
            res.SaveChanges();

            
            return RedirectToAction("logIn");
        }

        public ActionResult logIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult logIn(tbluser u)
        {
            tbluser usr = res.tblusers.Where(t => t.UserName.Equals(u.UserName) && t.Password.Equals(u.Password)).SingleOrDefault();
            if (usr != null)
            {
                Session["UserID"] = usr.UserID;
                Session["Username"] = usr.UserName;
                Session["Profile"] = usr.ProfilePic;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("logIn");
            }
            
        }

        public ActionResult getAllCities()
        {
            return View(res.tblcities.ToList());
        }

        public ActionResult MyArticles(int uid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                ViewBag.currentUserID = uid;
                return View(res.tblarticles.Where(t => t.UserID == uid).ToList());
            }
        }

        public ActionResult MyInfo()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                return View(res.tblusers.Where(t => t.UserID == uid).SingleOrDefault());
            }
        }


        [HttpPost]
        public ActionResult UpdateInfo(tbluser u)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                tbluser _user = res.tblusers.Where(t => t.UserID == u.UserID).SingleOrDefault();

                _user.FirstName = u.FirstName;
                _user.LastName = u.LastName;
                _user.MoNumber = u.MoNumber;
                _user.Email = u.Email;

                res.SaveChanges();

                return RedirectToAction("Index", new { id = _user.UserID });
            }
        }

        public ActionResult MyResearches(int uid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                ViewBag.currentUserID = uid;
                return View(res.tblresearches.Where(t => t.UserID == uid).ToList());
            }
        }

        public ActionResult MyResearcheReq()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                return View(res.tblresearchrequests.Where(t => t.tblresearch.UserID == uid).ToList());
            }
        }

        public ActionResult changeProfile()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                return View(res.tblusers.Where(t => t.UserID == uid).SingleOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateProfile(HttpPostedFileBase ProfilePic)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                tbluser u = res.tblusers.Where(t => t.UserID == uid).SingleOrDefault();
                var fileName = Path.GetFileName(ProfilePic.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/User"), fileName);
                ProfilePic.SaveAs(path);
                u.ProfilePic = fileName;
                Session["Profile"] = fileName;

                res.SaveChanges();

                return RedirectToAction("Index", new { id = uid });
            }
        }

        public ActionResult changePassword()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                return View(res.tblusers.Where(t => t.UserID == uid).SingleOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdatePassword()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                string olpass = Request["Opass"].ToString();
                string npass = Request["Npass"].ToString();

                int uid = Convert.ToInt32(Session["UserID"]);
                tbluser u = res.tblusers.Where(t => t.UserID == uid).SingleOrDefault();

                if (u.Password.Equals(olpass))
                {
                    u.Password = npass;
                    res.SaveChanges();
                    Session.Abandon();
                    return RedirectToAction("logIn");
                }
                else
                {
                    return RedirectToAction("Index", new { id = uid });
                }
            }
        }

        public ActionResult doLogOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn");
        }


    }
}