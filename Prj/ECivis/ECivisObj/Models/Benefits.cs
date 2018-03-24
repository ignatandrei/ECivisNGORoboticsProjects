using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Benefits
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long IdroboticEntity { get; set; }

        public RoboticEntity IdroboticEntityNavigation { get; set; }
    }
}
