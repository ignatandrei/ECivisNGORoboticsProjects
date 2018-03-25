using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class PhoneNumbers
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public long? IdcontactDetails { get; set; }

        public ContactDetails IdcontactDetailsNavigation { get; set; }
    }
}
