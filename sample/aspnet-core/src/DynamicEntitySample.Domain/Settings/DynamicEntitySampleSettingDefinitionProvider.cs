using Volo.Abp.Settings;

namespace DynamicEntitySample.Settings
{
    public class DynamicEntitySampleSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DynamicEntitySampleSettings.MySetting1));
        }
    }
}
