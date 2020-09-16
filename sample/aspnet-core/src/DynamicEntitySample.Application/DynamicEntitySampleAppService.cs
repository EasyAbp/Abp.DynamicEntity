using System;
using System.Collections.Generic;
using System.Text;
using DynamicEntitySample.Localization;
using Volo.Abp.Application.Services;

namespace DynamicEntitySample
{
    /* Inherit your application services from this class.
     */
    public abstract class DynamicEntitySampleAppService : ApplicationService
    {
        protected DynamicEntitySampleAppService()
        {
            LocalizationResource = typeof(DynamicEntitySampleResource);
        }
    }
}
