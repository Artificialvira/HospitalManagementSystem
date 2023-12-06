using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class HospitalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
