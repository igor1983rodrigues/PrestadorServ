import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxCurrencyModule } from 'ngx-currency';

import { PrestadoComponent } from './prestado.component';
import { PrestadoRoutingModule } from './prestado.routing';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PrestadoService } from './prestado.service';
import { PrestadoListaComponent } from './lista/prestado-lista.component';

@NgModule({
  declarations: [PrestadoComponent, PrestadoListaComponent],
  imports: [
    CommonModule,
    SharedModule,
    NgbModule,
    FormsModule,
    NgxCurrencyModule,
    ReactiveFormsModule,
    PrestadoRoutingModule
  ],
  exports: [PrestadoComponent, PrestadoListaComponent],
  providers: [PrestadoService]
})
export class PrestadoModule {
  /**
   *
   */
  constructor() {
    console.log('PrestadoModule');
  }
}
