namespace NeverGoodEnough.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using NeverGoodEnough.Models.BindingModels.GameObject;
    using NeverGoodEnough.Models.ViewModels.GameObject;
    using NeverGoodEnough.Services.Interfaces;

    [RoutePrefix("GameObject")]
    public class GameObjectsController : Controller
    {
        private IGameObjectService service;

        public GameObjectsController(IGameObjectService service)
        {
            this.service = service;
        }

        // GET: GameObjects
        [Route]
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllGameObject(User.Identity.GetUserId()));
        }

        // GET: GameObjects/Details/5
        [Route("Details/{id?}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsGameObjectVm gameObject = this.service.GetDetailGameObject(id);

            if (gameObject == null)
            {
                return HttpNotFound();
            }

            return View(gameObject);
        }

        // GET: GameObjects/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Name,Description,ImageUrl,Tags")] CreateGameObjectBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateGameObject(bm, User.Identity.GetUserId());
                return RedirectToAction("All");
            }

            return View();
        }

        // GET: GameObjects/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditGameObjectVm gameObject = this.service.GetEditGameObject(id);
            if (gameObject == null)
            {
                return HttpNotFound();
            }
            return View(gameObject);
        }

        // POST: GameObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageUrl,Tags")] EditGameObjectBm bm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditGameObject(bm);

                return RedirectToAction("All");
            }
            return View();
        }

        // GET: GameObjects/Delete/5
        [Route("Delete/{id?}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteGameObjectVm gameObject = this.service.GetDeleteGameObject(id);

            if (gameObject == null)
            {
                return HttpNotFound();
            }

            return View(gameObject);
        }

        // POST: GameObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteGameObject(id);

            return RedirectToAction("All");
        }
    }
}