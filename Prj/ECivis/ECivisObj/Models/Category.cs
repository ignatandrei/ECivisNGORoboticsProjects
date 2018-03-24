using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Category
    {
        public Category()
        {
            RoboticEntity = new HashSet<RoboticEntity>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoboticEntity> RoboticEntity { get; set; }
    }
}
