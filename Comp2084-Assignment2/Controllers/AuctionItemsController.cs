using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2084_Assignment2.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Comp2084_Assignment2.Controllers
{
    [Authorize]
    public class AuctionItemsController : Controller
    {
        private AzureDatabase db = new AzureDatabase();
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }
        // GET: AuctionItems
        public ActionResult Index()
        {
            //var auctionItems = db.AuctionItems.Include(a => a.AspNetUser);
            var user_id = User.Identity.GetUserId();
            var auctionItems = from data in db.AuctionItems
                               where user_id == data.user_id
                               select data;

            return View(auctionItems.ToList());
        }

        // GET: AuctionItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionItem auctionItem = db.AuctionItems.Find(id);
            if (auctionItem == null)
            {
                return HttpNotFound();
            }
            return View(auctionItem);
        }

        // GET: AuctionItems/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AuctionItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "title,description,price_expected,price_sold,profit,time_sold")] AuctionItem auctionItem, HttpPostedFileBase itemPic)
        {
            if (ModelState.IsValid)
            {
                auctionItem.user_id = User.Identity.GetUserId();
                auctionItem.time_created = DateTime.Now;

                if (itemPic != null && itemPic.ContentLength > 0)
                {
                    // Create the image url to be saved to the database
                    auctionItem.pic = Path.Combine("~/Content/Images", ConvertToTimestamp(DateTime.Now).ToString() + "-" + Path.GetFileName(itemPic.FileName));
                    itemPic.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), ConvertToTimestamp(DateTime.Now).ToString() + "-" + Path.GetFileName(itemPic.FileName)));

                } else
                {
                    // TODO : put some generic file pic
                    auctionItem.pic = "~/Content/Images/default-placeholder.png";
                }

                db.AuctionItems.Add(auctionItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", auctionItem.user_id);
            return View(auctionItem);
        }

        // GET: AuctionItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionItem auctionItem = db.AuctionItems.Find(id);
            if (auctionItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", auctionItem.user_id);
            return View(auctionItem);
        }

        // POST: AuctionItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "item_id,title,description,price_expected,price_sold,profit,time_created,time_sold,pic")] AuctionItem auctionItem, HttpPostedFileBase pic)
        {
            if (ModelState.IsValid)
            {
                auctionItem.user_id = User.Identity.GetUserId();

                if (pic != null && pic.ContentLength > 0)
                {
                    // Create the image url to be saved to the database
                    auctionItem.pic = Path.Combine("~/Content/Images", ConvertToTimestamp(DateTime.Now).ToString() + "-" + Path.GetFileName(pic.FileName));
                    pic.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), ConvertToTimestamp(DateTime.Now).ToString() + "-" + Path.GetFileName(pic.FileName)));

                }

                db.Entry(auctionItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.AspNetUsers, "Id", "Email", auctionItem.user_id);
            return View(auctionItem);
        }

        // GET: AuctionItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionItem auctionItem = db.AuctionItems.Find(id);
            if (auctionItem == null)
            {
                return HttpNotFound();
            }
            return View(auctionItem);
        }

        // POST: AuctionItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionItem auctionItem = db.AuctionItems.Find(id);
            db.AuctionItems.Remove(auctionItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
