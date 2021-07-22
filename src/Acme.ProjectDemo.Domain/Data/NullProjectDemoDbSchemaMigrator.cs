using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.ProjectDemo.Data
{
    /* This is used if database provider does't define
     * IProjectDemoDbSchemaMigrator implementation.
     */
    public class NullProjectDemoDbSchemaMigrator : IProjectDemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}