using Acme.ProjectDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.ProjectDemo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ProjectDemoEntityFrameworkCoreDbMigrationsModule),
        typeof(ProjectDemoApplicationContractsModule)
        )]
    public class ProjectDemoDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
