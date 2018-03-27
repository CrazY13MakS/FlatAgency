using System;
using System.Collections.Generic;

namespace FlatAgency.App_Data.DB
{
    public partial class FlatClass
    {
        public FlatClass()
        {
            Flat = new HashSet<Flat>();
        }

        public int FlatClassId { get; set; }
        public string Name { get; set; }

        public ICollection<Flat> Flat { get; set; }
    }
}
