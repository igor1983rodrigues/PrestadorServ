export interface IBaseService<T>{
    getPathApiService: string;
    getAll(callBack: Function): void;
}