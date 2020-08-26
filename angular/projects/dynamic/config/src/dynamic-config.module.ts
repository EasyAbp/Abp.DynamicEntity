import { ModuleWithProviders, NgModule } from '@angular/core';
import { MY_PROJECT_NAME_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class DynamicConfigModule {
  static forRoot(): ModuleWithProviders<DynamicConfigModule> {
    return {
      ngModule: DynamicConfigModule,
      providers: [MY_PROJECT_NAME_ROUTE_PROVIDERS],
    };
  }
}
