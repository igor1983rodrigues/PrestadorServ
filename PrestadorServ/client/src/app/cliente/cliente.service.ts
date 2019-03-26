import { Injectable } from '@angular/core';

import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ClienteService implements IBaseService {


    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/cliente`;

    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function) => this.httpClient.get<any[]>(this.getPathApiService)
        .subscribe((res: any[]) => callBack(res),
            error => console.error(error));
}