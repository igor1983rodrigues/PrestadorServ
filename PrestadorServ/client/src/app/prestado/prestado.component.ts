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
import { ActivatedRoute, Router } from '@angular/router';

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
  inscricao: Subscription;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private clienteService: ClienteService,
    private tipoServicoService: TipoServicoService,
    private fornecedorService: FornecedorService,
    private servicoPrestadoService: PrestadoService
  ) {
    this.limparModelo();
  }

  ngOnInit() {
    this.buildForm();
    //registerLocaleData(localePt, 'pt', localePtExtra);

    this.clienteService.getAll(res => this.clienteList = res);
    this.fornecedorService.getAll(res => this.fornecedorList = res);
    this.tipoServicoService.getAll(res => this.tipoServicoList = res);

    this.inscricao = this.activatedRoute.params.subscribe((p: { id: number }) => {
      if (!!p.id) {
        this.servicoPrestadoService.getById(p.id, res => {
          this.modelo = res;
          this.modelo.dataAtendimentoServicoPrestado = new Date(res.dataAtendimentoServicoPrestado);
          this.popularForm(res);
        });
      } else {
        this.popularForm(this.modelo);
      }
    });


  }

  private popularForm(m: ServicoPrestado) {
    Object.keys(m).forEach((label: string) => {
      if (this.form.contains(label)) {
        if ("dataAtendimentoServicoPrestado" == label) {
          let dt: string = m[label].toLocaleDateString().replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$3-$2-$1"),
            tm: string = m[label].toLocaleTimeString();
          this.form.get("dataAtendimentoServicoPrestado").setValue(dt);
          this.form.get("horaAtendimentoServicoPrestado").setValue(tm);
        } else {
          this.form.get(label).setValue(m[label]);
        }
      }
    });
  }
  private limparModelo = () => this.modelo = {
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

  limparForm = () => {
    this.limparModelo();
    this.form.reset();
  };


  private buildForm = (): void => {
    let dateTime = new Date();
    this.form = this.formBuilder.group({
      idCliente: [null, Validators.required],
      idFornecedor: [null, Validators.required],
      idTipoServico: [null, Validators.required],
      dataAtendimentoServicoPrestado: [dateTime.toDateString(), Validators.required],
      horaAtendimentoServicoPrestado: [dateTime.toTimeString(), Validators.required],
      descricaoServicoPrestado: [null],
      valorServicoPrestado: [null, Validators.compose([Validators.required, Validators.pattern("^\\d+(,\\d{1,2})?$")])]
    });
  };

  salvar = (): void => {

    let datetime = `${this.form.get("dataAtendimentoServicoPrestado").value}T${this.form.get("horaAtendimentoServicoPrestado").value}`;
    this.modelo.dataAtendimentoServicoPrestado = new Date(datetime);

    if (this.modelo.idServicoPrestado > 0)
      this.servicoPrestadoService.alterar(this.modelo, res => {
        alert(res.message);
        const url: string[] = this.router.url.split('/');
        url.pop();
        this.router.navigate(url);
      })
    else
      this.servicoPrestadoService.inserir(this.modelo, res => {
        alert(res.message);
        this.limparForm();
      })
  };
}
