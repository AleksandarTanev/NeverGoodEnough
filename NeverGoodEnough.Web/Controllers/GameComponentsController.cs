namespace NeverGoodEnough.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Services.Interfaces;

    [Authorize]
    [RoutePrefix("GameComponents")]
    public class GameComponentsController : Controller
    {
        private IGameComponentService service;

        public GameComponentsController(IGameComponentService service)
        {
            this.service = service;
        }

        // GET: GameMechanics
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllGameComponents());
        }

        // GET: GameMechanics
        [Route("MyAll")]
        public ActionResult MyAll()
        {
            return View(this.service.GetAllGameComponents(User.Identity.GetUserId()));
        }

        // GET: GameMechanics/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsGameComponentVm gameComponent = this.service.GetDetailGameComponent(id);

            if (gameComponent == null)
            {
                return HttpNotFound();
            }

            return View(gameComponent);
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
        public ActionResult Create([Bind(Include = "Name,Description,ImageUrl,Tags,Type")] CreateGameComponentBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateGameComponent(bm, User.Identity.GetUserId());
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

            EditGameComponentVm gameComponent = this.service.GetEditGameComponent(id);
            if (gameComponent == null)
            {
                return HttpNotFound();
            }
            return View(gameComponent);
        }

        // POST: GameMechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageUrl,Tags,Type")] EditGameComponentBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditGameComponent(bm);

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

            DeleteGameComponentVm gameComponent = this.service.GetDeleteGameComponent(id);

            if (gameComponent == null)
            {
                return HttpNotFound();
            }

            return View(gameComponent);
        }

        // POST: GameMechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteGameComponent(id);

            return RedirectToAction("All");
        }

        [HttpGet]
        [Route("AddToGame")]
        public ActionResult AddToGame(int id)
        {
            DetailsGameComponentVm gameComponent = this.service.GetDetailGameComponent(id);

            if (gameComponent == null)
            {
                return HttpNotFound();
            }

            return View(gameComponent);
        }

        [HttpPost]
        [Route("AddToGame")]
        public ActionResult AddToGame(int componentId, int gameId)
        {
            if (ModelState.IsValid)
            {
                this.service.AddToGame(componentId, gameId);
            }

            return RedirectToAction("All");
        }
    }
}
