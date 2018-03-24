using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class PhoneNumbers
    {
        public PhoneNumbers()
        {
            ContactDetails = new HashSet<ContactDetails>();
        }

        public long Id { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<ContactDetails> ContactDetails { get; set; }
    }
}
