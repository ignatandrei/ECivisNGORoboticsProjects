using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class Emails
    {
        public Emails()
        {
            ContactDetails = new HashSet<ContactDetails>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public ICollection<ContactDetails> ContactDetails { get; set; }
    }
}
