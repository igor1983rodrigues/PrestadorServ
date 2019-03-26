import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// import localePt from '@angular/common/locales/pt';
// import localePtExtra from '@angular/common/locales/extra/pt';
import { PrestadoService } from './prestador.service';
import { ClienteService } from '../cliente/cliente.service';
import { FornecedorService } from '../fornecedor/fornecedor.service';

@Component({
  selector: 'app-prestado',
  templateUrl: './prestado.component.html',
  styleUrls: ['./prestado.component.css']
})
export class PrestadoComponent implements OnInit {
 
  form: FormGroup;
  modelo: any = {};
  clienteList: any[];
  fornecedorList: any[];

  constructor(
    private formBuilder: FormBuilder,
    private clienteService: ClienteService,
    private fornecedorService: FornecedorService
  ) { }

  ngOnInit() {
    //registerLocaleData(localePt, 'pt', localePtExtra);

    this.clienteService.getAll(res => this.clienteList = res);
    this.fornecedorService.getAll(res => this.fornecedorList = res);

    this.form = this.formBuilder.group({
      idCliente: [null, Validators.required],
      idFornecedor: [null, Validators.required],
      dataAtendimentoServicoPrestado: [null, Validators.required],
      descricaoServicoPrestado: [null],
      valorServicoPrestado: [null, Validators.compose([Validators.required, Validators.pattern("^\\d+(,\\d{1,2})?$")])]
    });
  }

}
