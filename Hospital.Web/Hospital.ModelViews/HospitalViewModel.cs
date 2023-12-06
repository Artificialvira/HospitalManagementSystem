using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ModelViews
{
    public class HospitalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public HospitalViewModel()
        {
            
        }
        public HospitalViewModel(Hospitals model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            Pincode = model.Pincode;
            Country = model.Country;
        }
        public Hospitals ConvertViewModel(HospitalViewModel model)
        {
            return new Hospitals{
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                Pincode = model.Pincode,
                Country = model.Country,
            };
        }
    }
}
