using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Social
    {
        public Social()
        {
            ContactDetails = new HashSet<ContactDetails>();
        }

        public long Id { get; set; }
        public string Network { get; set; }
        public string Address { get; set; }

        public ICollection<ContactDetails> ContactDetails { get; set; }
    }
}
