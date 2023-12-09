using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contact.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {

        private IContactService _contact;
        private IHospitalInfo HospitalInfo;

        public ContactController(IContactService contact, IHospitalInfo hospitalInfo)
        {
            _contact = contact;
            HospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pagenumber = 1, int pagesize = 10)
        {
            return View(_contact.GetAll(pagenumber, pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(HospitalInfo.GetAll(), "Id", "Name");
            var viewmodel = _contact.GetContactById(id);
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel contactViewModel)
        {
            _contact.UpdateContact(contactViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.hospital = new SelectList(HospitalInfo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel ContactViewModel)
        {
            _contact.InsertContact(ContactViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}

