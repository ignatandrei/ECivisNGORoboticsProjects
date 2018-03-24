using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class RoboticEntity
    {
        public RoboticEntity()
        {
            Photos = new HashSet<Photos>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Idaddress { get; set; }
        public long Idcategory { get; set; }
        public string Description { get; set; }
        public long MemberCount { get; set; }
        public double? Rating { get; set; }
        public long IdcontactDetails { get; set; }
        public double? WomenPercentage { get; set; }
        public int? Sentiment { get; set; }

        public Address IdaddressNavigation { get; set; }
        public Category IdcategoryNavigation { get; set; }
        public ContactDetails IdcontactDetailsNavigation { get; set; }
        public ICollection<Photos> Photos { get; set; }
    }
}
