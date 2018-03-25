using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Emails
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public long? IdcontactDetails { get; set; }

        public ContactDetails ContactDetails { get; set; }
    }
}
