﻿namespace NeverGoodEnough.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;
    using NeverGoodEnough.Services;
    using NeverGoodEnough.Web.Attributes;

    [MyAuthorize(Roles = "Administrator")]
    [RouteArea("Administrator")]
    [RoutePrefix("Engineers")]
    public class EngineersController : Controller
    {
        private EngineersService service;

        public EngineersController()
        {
            this.service = new EngineersService();
        }

        // GET: Administrator/Engineers
        [Route("All")]
        public ActionResult All()
        {
            return View(this.service.GetAllEngineers());
        }
    }
}