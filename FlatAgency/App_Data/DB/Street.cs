using System;
using System.Collections.Generic;

namespace FlatAgency.App_Data.DB
{
    public partial class Street
    {
        public Street()
        {
            Flat = new HashSet<Flat>();
        }

        public int StreetId { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public District District { get; set; }
        public ICollection<Flat> Flat { get; set; }
    }
}
