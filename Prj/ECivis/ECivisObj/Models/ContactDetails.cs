using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class ContactDetails
    {
        public ContactDetails()
        {
            PhoneNumbers = new HashSet<PhoneNumbers>();
            RoboticEntity = new HashSet<RoboticEntity>();
            Social = new HashSet<Social>();
        }

        public long Id { get; set; }
        public string Website { get; set; }

        public Emails IdNavigation { get; set; }
        public ICollection<PhoneNumbers> PhoneNumbers { get; set; }
        public ICollection<RoboticEntity> RoboticEntity { get; set; }
        public ICollection<Social> Social { get; set; }
    }
}
