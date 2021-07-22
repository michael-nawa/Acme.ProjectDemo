using Acme.ProjectDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.ProjectDemo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ProjectDemoController : AbpController
    {
        protected ProjectDemoController()
        {
            LocalizationResource = typeof(ProjectDemoResource);
        }
    }
}