using System;
using System.Collections.Generic;

namespace ECivisObj.Models
{
    public partial class ContactDetails
    {
        public ContactDetails()
        {
            RoboticEntity = new HashSet<RoboticEntity>();
        }

        public long Id { get; set; }
        public long? IdphoneNumbers { get; set; }
        public long? Idemails { get; set; }
        public string Website { get; set; }
        public long? Idsocial { get; set; }

        public Emails IdemailsNavigation { get; set; }
        public PhoneNumbers IdphoneNumbersNavigation { get; set; }
        public Social IdsocialNavigation { get; set; }
        public ICollection<RoboticEntity> RoboticEntity { get; set; }
    }
}
