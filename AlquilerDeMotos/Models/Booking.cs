using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorcycleRent.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingStart{ get; set; }
        public DateTime BookingEnd { get; set; }
        public DateTime Delivery { get; set; }

        public string IdAppUser { get; set; }
        public int IdMotorcycle { get; set; }

        public AppUser AppUser { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }
}
