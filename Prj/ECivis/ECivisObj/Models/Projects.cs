using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Projects
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long IdteamLeader { get; set; }

        public TeamLeaders IdteamLeaderNavigation { get; set; }
    }
}
