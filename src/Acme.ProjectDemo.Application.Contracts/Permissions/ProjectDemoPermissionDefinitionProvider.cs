using Acme.ProjectDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.ProjectDemo.Permissions
{
    public class ProjectDemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

            var StoreGroup = context.AddGroup(ProjectDemoPermissions.GroupName, L("Permission:CustomerDetailsStore"));
            var customerDetailsPermission = StoreGroup.AddPermission(ProjectDemoPermissions.CustomerDetail.Default, L("Permission:CustomerDetails"));

            customerDetailsPermission.AddChild(ProjectDemoPermissions.CustomerDetail.Create, L("Permission:CustomerDetails.Create"));
            customerDetailsPermission.AddChild(ProjectDemoPermissions.CustomerDetail.Edit, L("Permission:CustomerDetails.Edit"));
            customerDetailsPermission.AddChild(ProjectDemoPermissions.CustomerDetail.Delete, L("Permission:CustomerDetails.Delete"));
            customerDetailsPermission.AddChild(ProjectDemoPermissions.CustomerDetail.Admin, L("Permission:CustomerDetails.Admin"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectDemoResource>(name);
        }
    }
}
