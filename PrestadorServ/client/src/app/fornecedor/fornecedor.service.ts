import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';
import { Fornecedor } from '../model/Fornecedor.entity';

@Injectable({ providedIn: 'root' })
export class FornecedorService implements IBaseService<Fornecedor> {

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/fornecedor`;

    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function) => this.httpClient.get<Fornecedor[]>(this.getPathApiService)
        .subscribe(res => callBack(res), error => console.error(error));
}