using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ModelViews
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInfoId { get; set; }
        public Hospitals Hospitals { get; set; }
        public RoomViewModel() { }
        public RoomViewModel(Room room)
        {
            Id = room.Id;
            RoomNumber = room.RoomNumber;
            Type = room.Type;
            Status = room.Status;
            HospitalInfoId = room.HospitalId;
            
        }
        public Room ConvertViewModel(RoomViewModel roomViewModel)
        {
            return new Room
            {
                Id = roomViewModel.Id,
                RoomNumber = roomViewModel.RoomNumber,
                Type = roomViewModel.Type,
                Status = roomViewModel.Status,
                HospitalId = roomViewModel.HospitalInfoId,
                
            };
        }
    }
}
