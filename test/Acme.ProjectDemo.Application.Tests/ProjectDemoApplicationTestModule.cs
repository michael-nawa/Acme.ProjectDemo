using Volo.Abp.Modularity;

namespace Acme.ProjectDemo
{
    [DependsOn(
        typeof(ProjectDemoApplicationModule),
        typeof(ProjectDemoDomainTestModule)
        )]
    public class ProjectDemoApplicationTestModule : AbpModule
    {

    }
}