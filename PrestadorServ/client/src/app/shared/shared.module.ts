import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TitleBarComponent } from './title-bar/title-bar.component';

@NgModule({
  declarations: [TitleBarComponent],
  imports: [CommonModule],
  exports: [TitleBarComponent],
  entryComponents: []
})
export class SharedModule { }
