import { Component, OnInit } from '@angular/core';
import { PrestadoService } from '../prestado/prestado.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  estatisticaClientes: any[] = null;
  mediasEstatistica: any[] = null;
  fornecedoresSemResultado: any[] = null;

  constructor(private prestadoService: PrestadoService) { }

  ngOnInit() {
    this.prestadoService.getMelhoresClientesEstatistica(res => this.estatisticaClientes = res);
    this.prestadoService.getMediaFornecedorEstatistica(res => this.mediasEstatistica = res);
    this.prestadoService.getFornecedorSemResultadoEstatistica(res => this.fornecedoresSemResultado = res);
  }
}
