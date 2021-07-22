using System.Threading.Tasks;

namespace Acme.ProjectDemo.Data
{
    public interface IProjectDemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
