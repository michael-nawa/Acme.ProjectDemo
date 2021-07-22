using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.ProjectDemo.Web
{
    [Dependency(ReplaceServices = true)]
    public class ProjectDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ProjectDemo";
    }
}
