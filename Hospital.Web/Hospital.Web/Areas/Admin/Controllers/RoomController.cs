using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Room.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {

        private IRoomService _room;

        public RoomController(IRoomService room)
        {
            _room = room;
        }

        public IActionResult Index(int pagenumber = 1, int pagesize = 10)
        {
            return View(_room.GetAll(pagenumber, pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
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

