using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Social
    {
        public long Id { get; set; }
        public string Network { get; set; }
        public string Address { get; set; }
        public long? IdcontactDetails { get; set; }

        public ContactDetails IdcontactDetailsNavigation { get; set; }
    }
}
