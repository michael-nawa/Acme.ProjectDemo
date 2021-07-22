using Acme.ProjectDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.ProjectDemo
{
    [DependsOn(
        typeof(ProjectDemoEntityFrameworkCoreTestModule)
        )]
    public class ProjectDemoDomainTestModule : AbpModule
    {

    }
}