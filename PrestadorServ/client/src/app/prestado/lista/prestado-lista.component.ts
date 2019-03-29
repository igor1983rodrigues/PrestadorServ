import { Component, OnInit } from '@angular/core';

import { ServicoPrestado } from 'src/app/model/servico-prestado.entity';
import { PrestadoService } from '../prestado.service';
import { ClienteService } from 'src/app/cliente/cliente.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-prestado-lista',
  templateUrl: './prestado-lista.component.html',
  styleUrls: ['./prestado-lista.component.css']
})
export class PrestadoListaComponent implements OnInit {

  parametros: any;
  ufs: any[];
  servicoPrestadoList: ServicoPrestado[];
  constructor(
    private clienteService: ClienteService,
    private servicoPrestadoService: PrestadoService
  ) { }

  ngOnInit() {
    this.limparFiltro();
    this.carregarLista();
    this.carregarUfs();
  }

  carregarUfs = (): Subscription => this.clienteService
    .getUFs((res: any) => {
      this.ufs = [];
      Object.keys(res).sort().forEach((key: string) => this.ufs.push({
        'key': key,
        'value': res[key]
      }));
    });

  carregarLista = (): Subscription => this.servicoPrestadoService
    .getList(this.parametros, res => this.servicoPrestadoList = res);

  limparFiltro = (): any => this.parametros = { uf: '' };
}
