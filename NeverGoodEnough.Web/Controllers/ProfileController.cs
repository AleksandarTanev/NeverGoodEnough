namespace NeverGoodEnough.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    [RoutePrefix("Profile")]
    public class ProfileController : Controller
    {
        // GET: Profile
        [Route]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("PersonalInfo")]
        public ActionResult PersonalInfo()
        {
            return PartialView("_EditPersonalInfo");
        }
    }
}