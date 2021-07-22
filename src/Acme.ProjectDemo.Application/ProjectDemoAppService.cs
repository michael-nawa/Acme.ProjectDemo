using System;
using System.Collections.Generic;
using System.Text;
using Acme.ProjectDemo.Localization;
using Volo.Abp.Application.Services;

namespace Acme.ProjectDemo
{
    /* Inherit your application services from this class.
     */
    public abstract class ProjectDemoAppService : ApplicationService
    {
        protected ProjectDemoAppService()
        {
            LocalizationResource = typeof(ProjectDemoResource);
        }
    }
}
