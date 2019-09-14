import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TitleBarComponent } from './title-bar/title-bar.component';
import { ContainerComponent } from './container/container.component';
import { ContainerFluidComponent } from './container-fluid/container-fluid.component';

@NgModule({
  declarations: [TitleBarComponent, ContainerComponent, ContainerFluidComponent],
  imports: [CommonModule],
  exports: [TitleBarComponent, ContainerComponent, ContainerFluidComponent],
  entryComponents: []
})
export class SharedModule { }
