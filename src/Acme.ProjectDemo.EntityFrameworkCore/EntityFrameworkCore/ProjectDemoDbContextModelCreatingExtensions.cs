using Acme.ProjectDemo.Entities.CustomerDetails;
using Acme.ProjectDemo.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.ProjectDemo.EntityFrameworkCore
{
    public static class ProjectDemoDbContextModelCreatingExtensions
    {
        public static void ConfigureProjectDemo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<CustomerDetail>(b =>
            {
                b.ToTable(ProjectDemoConsts.DbTablePrefix + "CustomerDetails",
                    ProjectDemoConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }
    }
}