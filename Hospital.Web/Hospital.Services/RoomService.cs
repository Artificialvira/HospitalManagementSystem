using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Repository.Interfaces;
using Hospital.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class RoomService : IRoomService
    {
        public readonly IUnitOfWork UnitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = UnitOfWork.GenericRepository<Room>().GetById(id);
            UnitOfWork.GenericRepository<Room>().Delete(model);
            UnitOfWork.save();
        }

        public PagedResult<RoomViewModel> GetAll(int pagenumber, int pagesize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> viewModels = new List<RoomViewModel>();
            try
            {
                int ExcludeRecords = (pagenumber * pagesize) - pagesize;
                var modelList = UnitOfWork.GenericRepository<Room>().GetAll().Skip(ExcludeRecords).Take(pagesize).ToList();
                totalCount = UnitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                viewModels = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<RoomViewModel>()
            {
                Data = viewModels,
                TotalItems = totalCount,
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            return result;
        }


        public RoomViewModel GetRoomById(int id)
        {
            throw new NotImplementedException();
        }
        public RoomViewModel GetHospitalById(int id)
        {
            var model = UnitOfWork.GenericRepository<Room>().GetById(id);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public void InsertRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            UnitOfWork.GenericRepository<Room>().Add(model);
            UnitOfWork.save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            var modelById = UnitOfWork.GenericRepository<Room>().GetById(model.Id);
            modelById.RoomNumber = model.RoomNumber;
            modelById.Status = model.Status;
            modelById.Type = model.Type;
            modelById.HospitalId = model.HospitalId;
            UnitOfWork.GenericRepository<Room>().Update(modelById);
            UnitOfWork.save();
        }
        public List<RoomViewModel> ConvertModelToViewModelList(List<Room> rooms)
        {
            return rooms.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
