using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorcycleRent.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }
        public int Cc { get; set; }
        public decimal Hp { get; set; }
        public decimal Price { get; set; }
        public int Km { get; set; }
        public bool Rented { get; set; }


        public List<Booking> AppUsers { get; set; }
    }
}
