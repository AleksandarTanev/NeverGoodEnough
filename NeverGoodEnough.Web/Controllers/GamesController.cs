﻿namespace NeverGoodEnough.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.ViewModels.Games;
    using NeverGoodEnough.Services.Interfaces;
    using Services;

    [Authorize]
    [RoutePrefix("Games")]
    public class GamesController : Controller
    {
        private IGamesService service;

        public GamesController(IGamesService service)
        {
            this.service = service;
        }

        // GET: Games
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllGames());
        }

        // GET: Games
        [Route("MyAll")]
        public ActionResult MyAll()
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
                return RedirectToAction("MyAll");
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

                return RedirectToAction("MyAll");
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

            return RedirectToAction("MyAll");
        }

        [ChildActionOnly]
        [Route("AvailableGames")]
        public ActionResult AvailableGames()
        {
            return PartialView("_AvailableGames", this.service.GetAllGames(User.Identity.GetUserId()));
        }

        [HttpPost]
        [Route("AddComponent")]
        public ActionResult AddComponent(int gameId, int mechanicId)
        {
            if (ModelState.IsValid)
            {
                this.service.AddComponentToGame(gameId, mechanicId, User.Identity.GetUserId());
            }

            return RedirectToAction("Details", new { id = gameId });
        }

        [HttpPost]
        [Route("RemoveComponent")]
        public ActionResult RemoveComponent(int gameId, int componentId)
        {
            if (ModelState.IsValid)
            {
                this.service.RemoveComponentFromGame(gameId, componentId, User.Identity.GetUserId());
            }

            return RedirectToAction("Edit", new { id = gameId });
        }
    }
}
