namespace NeverGoodEnough.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;
    using NeverGoodEnough.Services;
    using System.Net;
    using System.Web.Mvc;

    [Authorize]
    [RoutePrefix("GameVictoryConditions")]
    public class GameVictoryConditionsController : Controller
    {
        private IGameVictoryConditionsService service;

        public GameVictoryConditionsController(IGameVictoryConditionsService service)
        {
            this.service = service;
        }

        // GET: GameVictoryConditions
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllGameMechanics(User.Identity.GetUserId()));
        }

        // GET: GameVictoryConditions/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsGameVictoryConditionVm gameVCondition = this.service.GetDetailsGameVictoryCondition(id);

            if (gameVCondition == null)
            {
                return HttpNotFound();
            }

            return View(gameVCondition);
        }

        // GET: GameVictoryConditions/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameVictoryConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] CreateGameVictoryConditionBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateGameVictoryConditioc(bm, User.Identity.GetUserId());
                return RedirectToAction("All");
            }

            return View();
        }

        // GET: GameVictoryConditions/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditGameVictoryConditionVm gameVCondition = this.service.GetEditGameVictoryConditio(id);
            if (gameVCondition == null)
            {
                return HttpNotFound();
            }
            return View(gameVCondition);
        }

        // POST: GameVictoryConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] EditGameVictoryConditionBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditGameVictoryConditio(bm);

                return RedirectToAction("All");
            }
            return View();
        }

        // GET: GameVictoryConditions/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteGameVictoryConditionVm gameVCondition = this.service.GetDeleteGameVictoryCondition(id);

            if (gameVCondition == null)
            {
                return HttpNotFound();
            }

            return View(gameVCondition);
        }

        // POST: GameVictoryConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteGameVictoryCondition(id);

            return RedirectToAction("All");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
