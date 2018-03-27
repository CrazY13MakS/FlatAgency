using System;
using System.Collections.Generic;

namespace FlatAgency.App_Data.DB
{
    public partial class Flat
    {
        public int FlatId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateDelete { get; set; }
        public decimal Price { get; set; }
        public double Square { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public bool? IsDelete { get; set; }
        public int StreetId { get; set; }
        public string HouseNumber { get; set; }
        public int FlatClassId { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public int? ImagePath { get; set; }

        public FlatClass FlatClass { get; set; }
        public Street Street { get; set; }
    }
}
