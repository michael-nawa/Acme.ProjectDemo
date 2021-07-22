using Microsoft.EntityFrameworkCore;
using Acme.ProjectDemo.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using Acme.ProjectDemo.Entities.CustomerDetails;

namespace Acme.ProjectDemo.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See ProjectDemoMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class ProjectDemoDbContext : AbpDbContext<ProjectDemoDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside ProjectDemoDbContextModelCreatingExtensions.ConfigureProjectDemo
         */

        public ProjectDemoDbContext(DbContextOptions<ProjectDemoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser

                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the ProjectDemoEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureProjectDemo method */

            builder.ConfigureProjectDemo();
        }
    }
}
