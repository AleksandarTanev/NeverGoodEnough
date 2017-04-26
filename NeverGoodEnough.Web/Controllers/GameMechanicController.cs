namespace NeverGoodEnough.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using NeverGoodEnough.Data;
    using NeverGoodEnough.Models.EntityModels;

    [RoutePrefix("GameMechanics")]
    public class GameMechanicController : Controller
    {
        private NeverGoodEnoughContext db = new NeverGoodEnoughContext();

        // GET: GameMechanics
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            return View(db.GameMechanics.ToList());
        }

        // GET: GameMechanics/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMechanic gameMechanic = db.GameMechanics.Find(id);
            if (gameMechanic == null)
            {
                return HttpNotFound();
            }
            return View(gameMechanic);
        }

        // GET: GameMechanics/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameMechanics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] GameMechanic gameMechanic)
        {
            if (ModelState.IsValid)
            {
                db.GameMechanics.Add(gameMechanic);
                db.SaveChanges();
                return RedirectToAction("All");
            }

            return View(gameMechanic);
        }

        // GET: GameMechanics/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMechanic gameMechanic = db.GameMechanics.Find(id);
            if (gameMechanic == null)
            {
                return HttpNotFound();
            }
            return View(gameMechanic);
        }

        // POST: GameMechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] GameMechanic gameMechanic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameMechanic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View(gameMechanic);
        }

        // GET: GameMechanics/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMechanic gameMechanic = db.GameMechanics.Find(id);
            if (gameMechanic == null)
            {
                return HttpNotFound();
            }
            return View(gameMechanic);
        }

        // POST: GameMechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            GameMechanic gameMechanic = db.GameMechanics.Find(id);
            db.GameMechanics.Remove(gameMechanic);
            db.SaveChanges();
            return RedirectToAction("All");
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
