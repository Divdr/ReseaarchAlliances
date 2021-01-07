using Reseaarch_Alliances.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reseaarch_Alliances.Controllers
{
    public class ArticlesController : Controller
    {
        ResearchAlliances res = new ResearchAlliances();
        // GET: Articles
       
        

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblarticles.ToList());
            }
            
        }

        public ActionResult ArticleInfo(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                bool isAvilable = res.tblarticlelikes.ToList().Exists(t => t.ArticleID == id && t.UserID == uid);
                ViewBag.ArtLike = isAvilable;
                ViewData["ArticleComments"] = res.tblarticlecomments.Where(t => t.ArticleID == id).ToList();
                return View(res.tblarticles.Where(t => t.ArticleID == id).SingleOrDefault());
            }
        }

        public ActionResult likeUnlike(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                bool isAvilable = res.tblarticlelikes.ToList().Exists(t => t.ArticleID == id && t.UserID == uid);
                if (isAvilable)
                {
                    tblarticlelike alk = res.tblarticlelikes.Where(t => t.ArticleID == id && t.UserID == uid).SingleOrDefault();
                    res.tblarticlelikes.Remove(alk);
                }
                else
                {
                    tblarticlelike alk = new tblarticlelike();
                    alk.ArticleID = id;
                    alk.UserID = uid;
                    res.tblarticlelikes.Add(alk);
                }
                res.SaveChanges();
                ViewBag.avilable = isAvilable;
                return View();
            }
        }

        [HttpPost]
        public ActionResult PostComment(tblarticlecomment cmt)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                cmt.UserID = Convert.ToInt32(Session["UserID"]);
                res.tblarticlecomments.Add(cmt);
                res.SaveChanges();
                return RedirectToAction("ArticleInfo", new { id = cmt.ArticleID });
            }
        }

        public ActionResult AddArticle()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddArticle(tblarticle art,HttpPostedFileBase FeaturedImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                var fileName = Path.GetFileName(FeaturedImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/Post"), fileName);
                FeaturedImage.SaveAs(path);

                art.UserID = uid;
                art.FeaturedImage = fileName;

                res.tblarticles.Add(art);
                res.SaveChanges();
                return RedirectToAction("Index", "User", new { id = uid });
            }
        }

        public ActionResult getAllSubCategory()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblsubcategories.ToList());
            }
        }

        public ActionResult removeArticle(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);

                List<tblarticlelike> alk = res.tblarticlelikes.Where(t => t.ArticleID == id).ToList();

                for (int i = 0; i < alk.Count(); i++)
                {
                    res.tblarticlelikes.Remove(alk[i]);
                }

                tblarticle art = res.tblarticles.Where(t => t.ArticleID == id).SingleOrDefault();

                res.tblarticles.Remove(art);

                res.SaveChanges();

                return RedirectToAction("Index", "User", new { id = uid });
            }
        }

        public ActionResult EditArticle(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblarticles.Where(t => t.ArticleID == id).SingleOrDefault());
            }
                
        }

        [HttpPost]
        public ActionResult UpdateArticle(tblarticle a)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                tblarticle art = res.tblarticles.Where(t => t.ArticleID == a.ArticleID).SingleOrDefault();
                art.Title = a.Title;
                art.Description = a.Description;

                res.SaveChanges();
                return RedirectToAction("Index", "User", new { id = art.UserID });
            }
        }

        public ActionResult EditFeaturedArticle(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblarticles.Where(t => t.ArticleID == id).SingleOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateFeaturedArticle(tblarticle a,HttpPostedFileBase FeaturedImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                tblarticle art = res.tblarticles.Where(t => t.ArticleID == a.ArticleID).SingleOrDefault();
                var fileName = Path.GetFileName(FeaturedImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/Post"), fileName);
                FeaturedImage.SaveAs(path);

                art.FeaturedImage = fileName;

                res.SaveChanges();

                return RedirectToAction("Index", "User", new { id = art.UserID });
            }
        }
    }
}