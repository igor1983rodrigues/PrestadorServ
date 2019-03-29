import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrestadoComponent } from './prestado.component';
import { PrestadoListaComponent } from './lista/prestado-lista.component';

const prestadoRouters: Routes = [
  {
    path: '',
    component: PrestadoListaComponent,
    children: []
  },
  {
    path: 'add',
    component: PrestadoComponent
  },
  {
    path: ':id',
    component: PrestadoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(prestadoRouters)],
  exports: [RouterModule]
})
export class PrestadoRoutingModule { }
