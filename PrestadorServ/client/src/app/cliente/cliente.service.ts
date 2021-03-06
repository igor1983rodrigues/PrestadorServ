import { Injectable } from '@angular/core';

import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../model/cliente.entity';
import { Subscription } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ClienteService implements IBaseService<Cliente> {

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/cliente`;

    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function): Subscription => this.httpClient
        .get<Cliente[]>(this.getPathApiService)
        .subscribe((res: Cliente[]) => callBack(res), error => console.error(error));

    getUFs = (callback: Function): Subscription => this.httpClient
        .get<any>('assets/json/uf.json')
        .subscribe((res: any) => callback(res));
}