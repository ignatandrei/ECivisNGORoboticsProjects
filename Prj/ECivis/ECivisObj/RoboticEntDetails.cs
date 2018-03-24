﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECivisObj
{
    public class RoboticEntDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public long MemberCount { get; set; }
        public int? Rating { get; set; }
        public string ContactDetails { get; set; }
        public double? WomenPercentage { get; set; }
        public int? Sentiment { get; set; }

    }
}
