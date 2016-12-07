using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2084_Assignment2.Models;

namespace Comp2084_Assignment2.Controllers
{
    public class AuctionItemsController : Controller
    {
        private AzureDatabase db = new AzureDatabase();

        // GET: AuctionItems
        public ActionResult Index()
        {
            var auctionItems = db.AuctionItems.Include(a => a.AspNetUser);
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
        public ActionResult Create([Bind(Include = "item_id,user_id,title,description,price_expected,price_sold,profit,time_created,time_sold,pic")] AuctionItem auctionItem)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "item_id,user_id,title,description,price_expected,price_sold,profit,time_created,time_sold,pic")] AuctionItem auctionItem)
        {
            if (ModelState.IsValid)
            {
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
