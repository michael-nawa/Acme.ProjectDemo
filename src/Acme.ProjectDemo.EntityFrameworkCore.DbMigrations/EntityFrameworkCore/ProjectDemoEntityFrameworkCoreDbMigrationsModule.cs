using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Acme.ProjectDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProjectDemoEntityFrameworkCoreModule)
        )]
    public class ProjectDemoEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProjectDemoMigrationsDbContext>();
        }
    }
}
