using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Photos
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long IdroboticEntity { get; set; }

        public RoboticEntity IdroboticEntityNavigation { get; set; }
    }
}
