﻿using Hospital.ModelViews;
using Hospital.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalViewModel> GetAllPaged(int pageNumber,int pageSize);
        public List<HospitalViewModel> GetAll();
        HospitalViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo(HospitalViewModel HoapitalInfo);
        void InsertHospitalInfo(HospitalViewModel HoapitalInfo);
        void DeleteHospitalInfo(int HospitalId);
        void AddHospitalInfo(HospitalViewModel HospitalInfo);
    }
}
