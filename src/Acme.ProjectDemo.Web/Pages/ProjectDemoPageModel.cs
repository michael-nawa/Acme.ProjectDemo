using Acme.ProjectDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.ProjectDemo.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProjectDemoPageModel : AbpPageModel
    {
        protected ProjectDemoPageModel()
        {
            LocalizationResourceType = typeof(ProjectDemoResource);
        }
    }
}