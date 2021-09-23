using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba_JR.Models;

namespace Prueba_JR.Controllers
{
    public class CategoriasController : Controller
    {
        private PruebaJREntities db = new PruebaJREntities();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.Categoria.ToList());
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null)
            {
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit( Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var productos = db.Productos.SqlQuery("Select * from Productos where Id_cat=" + id + "")
                            .ToList();
            Categoria categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
            if (productos.Count > 0)
            {
                return RedirectToAction("Error");
            }
            else
            {
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            return View();
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
