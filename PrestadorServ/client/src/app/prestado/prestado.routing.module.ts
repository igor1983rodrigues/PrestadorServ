import { NgModule } from '@angular/core';
import { Router, Routes, RouterModule } from '@angular/router';
import { PrestadoComponent } from './prestado.component';

const prestadoRouters: Routes = [{
  path: '',
  component: PrestadoComponent,
  children: []
}];

@NgModule({
  imports: [RouterModule.forChild(prestadoRouters)],
  exports: [RouterModule]
})
export class PrestadoRoutingModule { }
