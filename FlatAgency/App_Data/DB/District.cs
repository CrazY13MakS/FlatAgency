using System;
using System.Collections.Generic;

namespace FlatAgency.App_Data.DB
{
    public partial class District
    {
        public District()
        {
            Street = new HashSet<Street>();
        }

        public int DistrictId { get; set; }
        public string Name { get; set; }

        public ICollection<Street> Street { get; set; }
    }
}
