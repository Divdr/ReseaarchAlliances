using Reseaarch_Alliances.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reseaarch_Alliances.Controllers
{
    public class ResearchController : Controller
    {
        ResearchAlliances res = new ResearchAlliances();

        // GET: Research
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblresearches.ToList());
            }
        }

        public ActionResult ResearchInfo(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                bool isRequestSend = res.tblresearchrequests.ToList().Exists(t => t.UserID == uid && t.ResearchID == id);
                ViewBag.isRequestSend = isRequestSend;
                bool isFollowed = res.tblresearchfollowers.ToList().Exists(t => t.UserID == uid && t.ResearchID == id);
                ViewBag.isFollowed = isFollowed;
                ViewData["researchUpdates"] = res.tblresearchupdates.Where(t => t.ResearchID == id).ToList();
                ViewData["researchUpdateLikes"] = res.tblresearchupdatelikes.ToList();
                return View(res.tblresearches.Where(t => t.ResearchID == id).SingleOrDefault());
            }
        }

        public ActionResult AddResearch()
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
        public ActionResult AddResearch(tblresearch r,HttpPostedFileBase FeaturedImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                var fileName = Path.GetFileName(FeaturedImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/Research"), fileName);
                FeaturedImage.SaveAs(path);

                r.UserID = uid;
                r.FeaturedImage = fileName;

                res.tblresearches.Add(r);

                res.SaveChanges();

                return RedirectToAction("Index", "User", new { id = uid });
            }
        }

        public ActionResult removeResearch(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);

                tblresearch r = res.tblresearches.Where(t => t.ResearchID == id).SingleOrDefault();
                res.tblresearches.Remove(r);

                res.SaveChanges();

                return RedirectToAction("Index", "User", new { id = uid });
            }
        }

        public ActionResult followRshRequest(int rid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);

                tblresearchrequest rshReq = new tblresearchrequest();
                rshReq.UserID = uid;
                rshReq.ResearchID = rid;

                res.tblresearchrequests.Add(rshReq);
                res.SaveChanges();

                return View();
            }
        }

        public ActionResult UnfollowRsh(int rid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);

                tblresearchfollower resFol = res.tblresearchfollowers.Where(t => t.ResearchID == rid && t.UserID == uid).SingleOrDefault();

                res.tblresearchfollowers.Remove(resFol);
                res.SaveChanges();

                return View(res.tblresearches.Where(t => t.ResearchID == rid).SingleOrDefault());
            }
        }


        public ActionResult AcceptRejectReq(int id,int op)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                tblresearchrequest resReq = res.tblresearchrequests.Where(t => t.ResearchRequestID == id).SingleOrDefault();
                if (op == 0)
                {
                    tblresearchfollower resFol = new tblresearchfollower();
                    resFol.ResearchID = resReq.ResearchID;
                    resFol.UserID = resReq.UserID;

                    res.tblresearchfollowers.Add(resFol);
                }
                res.tblresearchrequests.Remove(resReq);
                res.SaveChanges();
                return RedirectToAction("Index", "User", new { id = uid });
            }
        }

        public ActionResult EditResearch(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblresearches.Where(t => t.ResearchID == id).SingleOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateResearch(tblresearch r)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                tblresearch rsh = res.tblresearches.Where(t => t.ResearchID == r.ResearchID).SingleOrDefault();
                rsh.Title = r.Title;
                rsh.Description = r.Description;

                res.SaveChanges();
                return RedirectToAction("Index", "User", new { id = rsh.UserID });
            }
        }

        public ActionResult EditFeaturedResearch(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                return View(res.tblresearches.Where(t => t.ResearchID == id).SingleOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateFeaturedResearch(tblresearch r, HttpPostedFileBase FeaturedImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                tblresearch rsh = res.tblresearches.Where(t => t.ResearchID == r.ResearchID).SingleOrDefault();
                var fileName = Path.GetFileName(FeaturedImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/Research"), fileName);
                FeaturedImage.SaveAs(path);

                rsh.FeaturedImage = fileName;

                res.SaveChanges();

                return RedirectToAction("Index", "User", new { id = rsh.UserID });
            }
        }

        [HttpPost]
        public ActionResult postRshUpdate(int rid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                string rshDesc = Request["rshDesc"].ToString();
                int uid = Convert.ToInt32(Session["UserID"]);

                tblresearchupdate rshUpd = new tblresearchupdate();
                rshUpd.ResearchID = rid;
                rshUpd.UpdateDescription = rshDesc;
                rshUpd.UserID = uid;

                res.tblresearchupdates.Add(rshUpd);

                res.SaveChanges();

                return RedirectToAction("ResearchInfo", new { id = rid });
            }
        }

        public ActionResult likeUnlikeUpdate(int ruid)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserID"]);
                bool isAvailable = res.tblresearchupdatelikes.ToList().Exists(t => t.ResearchUpdateID == ruid && t.UserID == uid);
                if (isAvailable)
                {
                    tblresearchupdatelike alk = res.tblresearchupdatelikes.Where(t => t.ResearchUpdateID == ruid && t.UserID == uid).SingleOrDefault();
                    res.tblresearchupdatelikes.Remove(alk);
                }
                else
                {
                    tblresearchupdatelike alk = new tblresearchupdatelike();
                    alk.UserID = uid;
                    alk.ResearchUpdateID = ruid;

                    res.tblresearchupdatelikes.Add(alk);
                }
                res.SaveChanges();
                ViewBag.isliked = isAvailable;
                return View();
            }
        }
    }
}