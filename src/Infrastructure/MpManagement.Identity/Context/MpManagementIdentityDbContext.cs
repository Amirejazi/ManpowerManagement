using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MpManagement.Identity.Configurations;
using MpManagement.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Identity.Context
{
    public class MpManagementIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public MpManagementIdentityDbContext(DbContextOptions<MpManagementIdentityDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
