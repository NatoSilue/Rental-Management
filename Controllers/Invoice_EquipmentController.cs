using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalManagement.Models;

namespace RentalManagement.Controllers
{
    public class Invoice_EquipmentController : Controller
    {
        private RentalManagementEntities db = new RentalManagementEntities();

        // GET: Invoice_Equipment
        public ActionResult Index()
        {
            var invoice_Equipment = db.Invoice_Equipment.Include(i => i.Equipment).Include(i => i.Invoice);
            return View(invoice_Equipment.ToList());
        }

        // GET: Invoice_Equipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Equipment invoice_Equipment = db.Invoice_Equipment.Find(id);
            if (invoice_Equipment == null)
            {
                return HttpNotFound();
            }
            return View(invoice_Equipment);
        }

        // GET: Invoice_Equipment/Create
        public ActionResult Create()
        {
            ViewBag.Equipment_ID = new SelectList(db.Equipments, "Equipment_Id", "Equipment_Category");
            ViewBag.Invoice_ID = new SelectList(db.Invoices, "Invoice_ID", "Invoice_ID");
            return View();
        }

        // POST: Invoice_Equipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceEquipment_ID,Invoice_ID,Equipment_ID")] Invoice_Equipment invoice_Equipment)
        {
            if (ModelState.IsValid)
            {
                db.Invoice_Equipment.Add(invoice_Equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Equipment_ID = new SelectList(db.Equipments, "Equipment_Id", "Equipment_Category", invoice_Equipment.Equipment_ID);
            ViewBag.Invoice_ID = new SelectList(db.Invoices, "Invoice_ID", "Invoice_ID", invoice_Equipment.Invoice_ID);
            return View(invoice_Equipment);
        }

        // GET: Invoice_Equipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Equipment invoice_Equipment = db.Invoice_Equipment.Find(id);
            if (invoice_Equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Equipment_ID = new SelectList(db.Equipments, "Equipment_Id", "Equipment_Category", invoice_Equipment.Equipment_ID);
            ViewBag.Invoice_ID = new SelectList(db.Invoices, "Invoice_ID", "Invoice_ID", invoice_Equipment.Invoice_ID);
            return View(invoice_Equipment);
        }

        // POST: Invoice_Equipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceEquipment_ID,Invoice_ID,Equipment_ID")] Invoice_Equipment invoice_Equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_Equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Equipment_ID = new SelectList(db.Equipments, "Equipment_Id", "Equipment_Category", invoice_Equipment.Equipment_ID);
            ViewBag.Invoice_ID = new SelectList(db.Invoices, "Invoice_ID", "Invoice_ID", invoice_Equipment.Invoice_ID);
            return View(invoice_Equipment);
        }

        // GET: Invoice_Equipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Equipment invoice_Equipment = db.Invoice_Equipment.Find(id);
            if (invoice_Equipment == null)
            {
                return HttpNotFound();
            }
            return View(invoice_Equipment);
        }

        // POST: Invoice_Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice_Equipment invoice_Equipment = db.Invoice_Equipment.Find(id);
            db.Invoice_Equipment.Remove(invoice_Equipment);
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
