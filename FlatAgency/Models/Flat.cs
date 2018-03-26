using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatAgency.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
      //  public DateTime DateDeletion { get; set; }
        public decimal Price { get; set; }
        public double Square { get; set; }
        public String District { get; set; }
        public String Address { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public String Class { get; set; }
    }
}
