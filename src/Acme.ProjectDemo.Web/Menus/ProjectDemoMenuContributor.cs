using System.Threading.Tasks;
using Acme.ProjectDemo.Localization;
using Acme.ProjectDemo.MultiTenancy;
using Acme.ProjectDemo.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.ProjectDemo.Web.Menus
{
    public class ProjectDemoMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<ProjectDemoResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    ProjectDemoMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            if (await context.IsGrantedAsync(ProjectDemoPermissions.CustomerDetail.Default))
            {
                context.Menu.Items.Insert(
                       0,
                       new ApplicationMenuItem(
                           ProjectDemoMenus.Profile,
                           "Profile",
                           "/Customer/CustomerDetails",
                           icon: "fas fa-users",
                           order: 1
                       )
                   );
            }

            if (await context.IsGrantedAsync(ProjectDemoPermissions.CustomerDetail.Admin))
            {
                context.Menu.Items.Insert(
                    0,
                    new ApplicationMenuItem(
                        ProjectDemoMenus.Customers,
                        "Customers Data",
                        "/Admin/CustomerDetails",
                        icon: "fas fa-users",
                        order: 2
                    )
                );
            }


            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        }
    }
}
