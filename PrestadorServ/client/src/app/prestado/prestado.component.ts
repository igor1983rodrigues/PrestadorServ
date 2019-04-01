import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// import localePt from '@angular/common/locales/pt';
// import localePtExtra from '@angular/common/locales/extra/pt';
import { ClienteService } from '../cliente/cliente.service';
import { FornecedorService } from '../fornecedor/fornecedor.service';
import { Cliente } from '../model/cliente.entity';
import { Fornecedor } from '../model/Fornecedor.entity';
import { TipoServico } from '../model/tipo-servico.entity';
import { TipoServicoService } from '../tipoServico/tipo-servico.service';
import { Subscription } from 'rxjs';
import { PrestadoService } from './prestado.service';
import { ServicoPrestado } from '../model/servico-prestado.entity';

@Component({
  selector: 'app-prestado',
  templateUrl: './prestado.component.html',
  styleUrls: ['./prestado.component.css']
})
export class PrestadoComponent implements OnInit {

  form: FormGroup;
  modelo: ServicoPrestado;
  clienteList: Cliente[];
  fornecedorList: Fornecedor[];
  tipoServicoList: TipoServico[];

  constructor(
    private formBuilder: FormBuilder,
    private clienteService: ClienteService,
    private tipoServicoService: TipoServicoService,
    private fornecedorService: FornecedorService,
    private servicoPrestadoService: PrestadoService
  ) {
    this.modelo = {
      idFornecedor: null,
      dataAtendimentoServicoPrestado: new Date(),
      idCliente: null,
      idServicoPrestado: 0,
      descricaoServicoPrestado: null,
      idTipoServico: null,
      valorServicoPrestado: null,
      cliente: null,
      fornecedor: null,
      tipoServico: null
    };
  }

  ngOnInit() {
    //registerLocaleData(localePt, 'pt', localePtExtra);

    this.clienteService.getAll(res => this.clienteList = res);
    this.fornecedorService.getAll(res => this.fornecedorList = res);
    this.tipoServicoService.getAll(res => this.tipoServicoList = res);


    let dateTime = new Date();
    this.form = this.formBuilder.group({
      idCliente: [null, Validators.required],
      idFornecedor: [null, Validators.required],
      idTipoServico: [null, Validators.required],
      dataAtendimentoServicoPrestado: [null, Validators.required],
      horaAtendimentoServicoPrestado: [dateTime.toLocaleDateString(), Validators.required],
      descricaoServicoPrestado: [null],
      valorServicoPrestado: [null, Validators.compose([Validators.required, Validators.pattern("^\\d+(,\\d{1,2})?$")])]
    });
  }

  salvar = (): void => {
    this.servicoPrestadoService.salvar(this.modelo, res => {
      alert(res.message);
    });
  };
}
