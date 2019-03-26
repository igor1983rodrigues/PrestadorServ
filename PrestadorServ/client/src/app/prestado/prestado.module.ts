import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { PrestadoComponent } from './prestado.component';
import { PrestadoRoutingModule } from './prestado.routing.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClienteService } from '../cliente/cliente.service';
import { PrestadoService } from './prestador.service';

@NgModule({
  declarations: [PrestadoComponent],
  imports: [
    CommonModule,
    SharedModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    PrestadoRoutingModule
  ],
  exports: [PrestadoComponent],
  providers: [PrestadoService]
})
export class PrestadoModule { }
