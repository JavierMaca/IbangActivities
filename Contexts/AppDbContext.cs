using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creation_activities_ibang.Entities;
using Microsoft.EntityFrameworkCore;


namespace creation_activities_ibang.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {
        
        }
        public DbSet<User> User { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ReportTime> ReportTime { get; set; }

    }
}
