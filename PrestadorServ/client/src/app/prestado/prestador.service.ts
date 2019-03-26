import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { IBaseService } from '../utils/ibase.service';
import { GeneralConfig } from '../config/generic.config';

@Injectable({providedIn: 'root'})
export class PrestadoService implements IBaseService {

    getPathApiService: string = `${GeneralConfig.WEBAPI_URL}/api/prestado`;

    constructor(private httpClient: HttpClient) { }

    getAll = (callBack: Function) => this.httpClient.get<any[]>(this.getPathApiService).subscribe((res: any[]) => callBack(res));
}