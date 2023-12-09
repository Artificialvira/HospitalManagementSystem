using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Room.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {

        private IRoomService _room;
        private IHospitalInfo HospitalInfo;

        public RoomController(IRoomService room, IHospitalInfo hospitalInfo)
        {
            _room = room;
            HospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pagenumber = 1, int pagesize = 10)
        {
            return View(_room.GetAll(pagenumber, pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(HospitalInfo.GetAll(), "Id", "Name");
            var viewmodel = _room.GetRoomById(id);
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {
            _room.UpdateRoom(roomViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.hospital = new SelectList(HospitalInfo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel RoomViewModel)
        {
            _room.InsertRoom(RoomViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}

