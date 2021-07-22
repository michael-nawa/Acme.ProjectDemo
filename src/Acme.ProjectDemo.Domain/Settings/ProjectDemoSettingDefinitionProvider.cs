using Volo.Abp.Settings;

namespace Acme.ProjectDemo.Settings
{
    public class ProjectDemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ProjectDemoSettings.MySetting1));
        }
    }
}
