import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { DynamicComponent } from './components/dynamic.component';
import { DynamicRoutingModule } from './dynamic-routing.module';

@NgModule({
  declarations: [DynamicComponent],
  imports: [CoreModule, ThemeSharedModule, DynamicRoutingModule],
  exports: [DynamicComponent],
})
export class DynamicModule {
  static forChild(): ModuleWithProviders<DynamicModule> {
    return {
      ngModule: DynamicModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<DynamicModule> {
    return new LazyModuleFactory(DynamicModule.forChild());
  }
}
