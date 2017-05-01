namespace NeverGoodEnough.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Data;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Services;

    [Authorize]
    [RoutePrefix("GameMechanics")]
    public class GameMechanicsController : Controller
    {
        private NeverGoodEnoughContext db = new NeverGoodEnoughContext();

        private IGameMechanicService service;

        public GameMechanicsController(IGameMechanicService service)
        {
            this.service = service;
        }

        // GET: GameMechanics
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            //return View(db.GameMechanics.ToList());
            var user = User.Identity.GetUserId();
            return View(this.service.GetAllGameMechanics(0));
        }

        // GET: GameMechanics/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsGameMechanicVm gameMechanic = this.service.GetDetailGameMechanic(id);

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
        public ActionResult Create([Bind(Include = "Id,Name,Description")] CreateGameMechanicBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateGameMechanic(bm);
                return RedirectToAction("All");
            }

            return View();
        }

        // GET: GameMechanics/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditGameMechanicVm gameMechanic = this.service.GetEditGameMechanic(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] EditGameMechanicBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditGameMechanic(bm);

                return RedirectToAction("All");
            }
            return View();
        }

        // GET: GameMechanics/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteGameMechanicVm gameMechanic = this.service.GetDeleteGameMechanic(id);

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
            this.service.DeleteGameMechanic(id);

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
