using System;
using System.Collections.Generic;
using System.Text;
using DynamicSample.Localization;
using Volo.Abp.Application.Services;

namespace DynamicSample
{
    /* Inherit your application services from this class.
     */
    public abstract class DynamicSampleAppService : ApplicationService
    {
        protected DynamicSampleAppService()
        {
            LocalizationResource = typeof(DynamicSampleResource);
        }
    }
}
