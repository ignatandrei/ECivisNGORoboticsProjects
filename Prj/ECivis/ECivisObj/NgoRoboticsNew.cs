﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECivisObj.Models
{
    public partial class NGORoboticsContext : DbContext
    {
        public NGORoboticsContext(DbContextOptions<NGORoboticsContext> options)
    : base(options)
        { }


        public async Task<RoboticEntDetails[]> DetailsRobotics(int? IDCategory)
        {
            IQueryable<RoboticEntity> robs = this.RoboticEntity;
            if (IDCategory != null)
            {
                var cat = IDCategory.Value;
                robs = robs.Where(it => it.Idcategory == cat);
            }
            var data = robs
                .Include(it => it.IdcontactDetailsNavigation.Social)
                .Include(it => it.IdcontactDetailsNavigation.IdNavigation)
                .Include(it => it.IdcontactDetailsNavigation.PhoneNumbers)
                .Select(it => new RoboticEntDetails()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Lat = it.IdaddressNavigation.Lat,
                    Long = it.IdaddressNavigation.Long,
                    MemberCount = it.MemberCount,
                    WomenPercentage = it.WomenPercentage,
                    Rating = it.Rating,
                    Sentiment = it.Sentiment,
                    Address = it.IdaddressNavigation.AddressDetails,
                    Description = it.Description,
                    Benefits = it.Benefits,
                    Category = it.IdcategoryNavigation.Name,
                    ContactDetails = it.IdcontactDetailsNavigation,
                    Photos = it.Photos
            })
            .OrderBy(it => it.Name);
            return await data.ToArrayAsync();
        }
    }
}
