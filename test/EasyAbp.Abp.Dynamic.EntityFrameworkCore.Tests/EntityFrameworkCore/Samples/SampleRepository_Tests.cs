﻿using EasyAbp.Abp.Dynamic.Samples;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore.Samples
{
    public class SampleRepository_Tests : SampleRepository_Tests<DynamicEntityFrameworkCoreTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to EF core.
         */
    }
}
