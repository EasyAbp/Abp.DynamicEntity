using Volo.Abp.Settings;

namespace DynamicSample.Settings
{
    public class DynamicSampleSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DynamicSampleSettings.MySetting1));
        }
    }
}
