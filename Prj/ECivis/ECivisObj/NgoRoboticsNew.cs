using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECivisObj.Models
{
    public partial class NGORoboticsContext : DbContext
    {
        public NGORoboticsContext(DbContextOptions<NGORoboticsContext> options)
    : base(options)
        { }


        public RoboticEntDetails[] DetailsRobotics(int? IDCategory)
        {
            IQueryable<RoboticEntity> robs = this.RoboticEntity;
            if (IDCategory != null)
            {
                var cat = IDCategory.Value;
                robs = robs.Where(it => it.Idcategory == cat);
            }
            return robs.Select(it => new RoboticEntDetails()
            {
                Name = it.Name,
                Lat = it.IdaddressNavigation.Lat,
                Long = it.IdaddressNavigation.Long
            })
            .OrderBy(it => it.Name)
            .ToArray();
        }
    }
}
