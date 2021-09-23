using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba_JR.Models;

namespace Prueba_JR.Controllers
{
    public class ProductosController : Controller
    {
        private PruebaJREntities db = new PruebaJREntities();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categoria);
            return View(productos.ToList());
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Id_cat = new SelectList(db.Categoria, "Id_cat", "CatNombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_cat = new SelectList(db.Categoria, "Id_cat", "CatNombre", productos.Id_cat);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Id_cat = new SelectList(db.Categoria, "Id_cat", "CatNombre", productos.Id_cat);
            return View(productos);
        }

        
        [HttpPost]
        public ActionResult Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_cat = new SelectList(db.Categoria, "Id_cat", "CatNombre", productos.Id_cat);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
