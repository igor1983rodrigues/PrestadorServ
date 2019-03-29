import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';

import { HomeRoutingModule } from './home.routing.module';
import { SharedModule } from '../shared/shared.module';
import { PrestadoService } from '../prestado/prestado.service';

@NgModule({
  declarations: [HomeComponent],
  providers: [PrestadoService],
  imports: [
    CommonModule,
    SharedModule,
    HomeRoutingModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
