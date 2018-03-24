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
        public long Idadress { get; set; }

        public Adress IdadressNavigation { get; set; }
        public ICollection<Photos> Photos { get; set; }
    }
}
