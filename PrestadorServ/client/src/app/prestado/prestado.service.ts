import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';
import { ServicoPrestado } from '../model/servico-prestado.entity';

@Injectable({ providedIn: 'root' })
export class PrestadoService implements IBaseService<ServicoPrestado> {

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/prestado`;

    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function): Subscription => this.httpClient.get<ServicoPrestado[]>(this.getPathApiService).subscribe((res: any[]) => callBack(res));

    getList = (parametros: any, callback: Function): Subscription => this.httpClient
        .get<ServicoPrestado[]>(this.getPathApiService, {
            params: parametros
        }).subscribe((res: ServicoPrestado[]) => callback(res));

    getMelhoresClientesEstatistica = <T>(callBack: Function): Subscription => this.httpClient
        .get<T[]>(`${this.getPathApiService}/maioresconsumidores`)
        .subscribe((res: T[]) => callBack(res));

    getMediaFornecedorEstatistica = <T>(callback: Function): Subscription => this.httpClient
        .get<T[]>(`${this.getPathApiService}/mediafornecedorestiposervico`)
        .subscribe((res: T[]) => callback(res));

    getFornecedorSemResultadoEstatistica = <T>(callback: Function): Subscription => this.httpClient
        .get<T[]>(`${this.getPathApiService}/fornecedoressemresultado`)
        .subscribe((res: T[]) => callback(res));

    salvar = (modelo: ServicoPrestado, callBack: Function): Subscription => this.httpClient
        .post(this.getPathApiService, modelo)
        .subscribe((res: any) => callBack(res));
}