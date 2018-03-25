using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class TeamLeaders
    {
        public TeamLeaders()
        {
            Projects = new HashSet<Projects>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

        public ICollection<Projects> Projects { get; set; }
    }
}
