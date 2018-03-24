using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Address
    {
        public Address()
        {
            RoboticEntity = new HashSet<RoboticEntity>();
        }

        public long Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string AddressDetails { get; set; }

        public ICollection<RoboticEntity> RoboticEntity { get; set; }
    }
}
