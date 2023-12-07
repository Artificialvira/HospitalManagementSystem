using Hospital.Models;
using Hospital.ModelViews;
using Hospital.Repository.Implementation;
using Hospital.Repository.Interfaces;
using Hospital.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class HospitalInfo:IHospitalInfo
    {
        public readonly IUnitOfWork _unitOfWork;

        public HospitalInfo(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void AddHospitalInfo(HospitalViewModel HospitalInfo)
        {
            throw new NotImplementedException();
        }

        public void DeleteHospitalInfo(int HospitalId)
        {
            var model = _unitOfWork.GenericRepository<Hospitals>().GetById(HospitalId);
            _unitOfWork.GenericRepository<Hospitals>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HospitalViewModel();
            int totalCount;
            List<HospitalViewModel> vmList = new List<HospitalViewModel>();
            try
            {
                int ExcludeRecords = (pageNumber * pageSize) - pageSize;
                List<Hospitals> _modelList = _unitOfWork.GenericRepository<Hospitals>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Hospitals>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(_modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<HospitalViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public HospitalViewModel GetHospitalById(int HospitalId)
        {
            var model = _unitOfWork.GenericRepository<Hospitals>().GetById(HospitalId);
            var vm = new HospitalViewModel(model);
            return vm;
        }

        public void InsertHospitalInfo(HospitalViewModel HoapitalInfo)
        {
            var model = new HospitalViewModel().ConvertViewModel(HoapitalInfo);
            _unitOfWork.GenericRepository<Hospitals>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateHospitalInfo(HospitalViewModel HoapitalInfo)
        {
            var model = new HospitalViewModel().ConvertViewModel(HoapitalInfo);
            var ModelById = _unitOfWork.GenericRepository<Hospitals>().GetById(model.Id);
            ModelById.Name = model.Name;
            ModelById.Country = model.Country;
            ModelById.Rooms = model.Rooms;
            ModelById.Id = model.Id;
            _unitOfWork.GenericRepository<Hospitals>().Update(model);
            _unitOfWork.save();
        }

        private List<HospitalViewModel> ConvertModelToViewModelList(List<Hospitals> modelList)
        {
            return modelList.Select(x => new HospitalViewModel(x)).ToList();
        }



    }
}
