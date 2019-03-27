import { HttpClient } from "@angular/common/http";
import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class FornecedorService implements IBaseService<any> {

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/fornecedor`;
    
    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function) => this.httpClient.get<any[]>(this.getPathApiService).subscribe(res => callBack(res),error => console.error(error));
}