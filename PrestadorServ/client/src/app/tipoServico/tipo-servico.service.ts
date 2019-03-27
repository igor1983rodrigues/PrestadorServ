import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { IBaseService } from "../utils/ibase.service";
import { TipoServico } from '../model/tipo-servico.entity';
import { GeneralConfig } from '../config/generic.config';

@Injectable({ providedIn: 'root' })
export class TipoServicoService implements IBaseService<TipoServico> {

    constructor(private httpClient: HttpClient) { }

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/tiposervico`;

    getAll = (callBack: Function) => this.httpClient.get<TipoServico[]>(this.getPathApiService)
        .subscribe(res => callBack(res), error => console.error(error));
}