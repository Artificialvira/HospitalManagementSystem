using Hospital.ModelViews;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]

    public class HospitalsController : Controller
    {
        private IHospitalInfo _hospitalInfo;

        public HospitalsController(IHospitalInfo hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pagenumber =1,int pagesize=10)
        {
            return View(_hospitalInfo.GetAll(pagenumber,pagesize));
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewmodel = _hospitalInfo.GetHospitalById(id);
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalViewModel hospitalViewModel) 
        {
            _hospitalInfo.UpdateHospitalInfo(hospitalViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create(int id) 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalViewModel hospitalViewModel)
        {
            _hospitalInfo.InsertHospitalInfo(hospitalViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        }
    }
}
