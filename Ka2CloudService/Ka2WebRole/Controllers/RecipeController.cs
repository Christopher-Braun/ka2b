using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ka2WebRole.Models;
using Mvc4WebRole.Models;

namespace Ka2WebRole.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipe
        public ActionResult Index()
        {
            return View(db.RecipeModels.ToList());
        }

        // GET: Recipe/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeModel recipeModel = db.RecipeModels.Find(id);
            if (recipeModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeModel);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DefaultPersonCount,LastTimeChanged,TimeCreated,Author,Hint")] RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                recipeModel.ID = Guid.NewGuid();
                recipeModel.LastTimeChanged = DateTime.UtcNow;
                recipeModel.TimeCreated = DateTime.UtcNow;

                db.RecipeModels.Add(recipeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipeModel);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeModel recipeModel = db.RecipeModels.Find(id);
            if (recipeModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeModel);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DefaultPersonCount,LastTimeChanged,TimeCreated,Author,Hint")] RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeModel);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeModel recipeModel = db.RecipeModels.Find(id);
            if (recipeModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeModel);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RecipeModel recipeModel = db.RecipeModels.Find(id);
            db.RecipeModels.Remove(recipeModel);
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
