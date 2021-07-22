using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.ProjectDemo.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.ProjectDemo.EntityFrameworkCore
{
    public class EntityFrameworkCoreProjectDemoDbSchemaMigrator
        : IProjectDemoDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreProjectDemoDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ProjectDemoMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ProjectDemoMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}