using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ECivisObj.Models
{
    public partial class NGORoboticsContext : DbContext
    {
        public NGORoboticsContext(DbContextOptions<NGORoboticsContext> options)
    : base(options)
        { }

    }
}
