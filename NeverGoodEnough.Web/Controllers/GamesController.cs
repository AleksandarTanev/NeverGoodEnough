namespace NeverGoodEnough.Web.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Web.Mvc;
    using Data;
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.Games;
    using NeverGoodEnough.Services.Interfaces;
    using Services;

    [RoutePrefix("Games")]
    public class GamesController : Controller
    {
        private NeverGoodEnoughContext db;

        private IGamesService service;

        public GamesController(IGamesService service)
        {
            this.service = service;
        }

        // GET: Games
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllGames(User.Identity.GetUserId()));
        }

        // GET: Games/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsGameVm vm = this.service.GetDetailGame(id);

            if (vm == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }

        // GET: Games/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Name,Description")] CreateGameBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateGame(bm, User.Identity.GetUserId());
                return RedirectToAction("All");
            }

            return View();
        }

        // GET: Games/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditGameVm vm = this.service.GetEditGame(id);
            if (vm == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] EditGameBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditGame(bm);

                return RedirectToAction("All");
            }
            return View();
        }

        // GET: Games/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteGameVm gameMechanic = this.service.GetDeleteGame(id);

            if (gameMechanic == null)
            {
                return HttpNotFound();
            }

            return View(gameMechanic);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteGame(id);

            return RedirectToAction("All");
        }

        [ChildActionOnly]
        [Route("AvailableMechanics")]
        public ActionResult AvailableMechanics()
        {
            var service = new GameMechanicService();

            return PartialView("_AvailableMechanics", service.GetAllGameMechanics(User.Identity.GetUserId()));
        }

        [HttpPost]
        [Route("AddMechanic")]
        public ActionResult AddMechanic(int gameId, int mechanicId)
        {
            if (ModelState.IsValid)
            {
                this.service.AddMechanicToGame(gameId, mechanicId, User.Identity.GetUserId());
            }

            return RedirectToAction("Details", new { id = gameId });
        }

        [ChildActionOnly]
        [Route("AvailableVictoryConditions")]
        public ActionResult AvailableVictoryConditions()
        {
            var service = new GameVictoryConditionsService();

            return PartialView("_AvailableVConditions", service.GetAllGameMechanics(User.Identity.GetUserId()));
        }

        [HttpPost]
        [Route("AddVictoryCondition")]
        public ActionResult AddVictoryCondition(int gameId, int victoryConditionId)
        {
            if (ModelState.IsValid)
            {
                this.service.AddVictoryConditionToGame(gameId, victoryConditionId, User.Identity.GetUserId());
            }

            return RedirectToAction("Details", new { id = gameId });
        }

        [HttpPost]
        [Route("RemoveMechanic")]
        public ActionResult RemoveMechanic(int gameId, int mechanicId)
        {
            if (ModelState.IsValid)
            {
                this.service.RemoveMechanicFromGame(gameId, mechanicId, User.Identity.GetUserId());
            }

            return RedirectToAction("Details", new { id = gameId });
        }

        [HttpPost]
        [Route("RemoveVictoryCondition")]
        public ActionResult RemoveVictoryCondition(int gameId, int victoryConditionId)
        {
            if (ModelState.IsValid)
            {
                this.service.RemoveVictoryConditionFromGame(gameId, victoryConditionId, User.Identity.GetUserId());
            }

            return RedirectToAction("Details", new { id = gameId });
        }
    }
}
