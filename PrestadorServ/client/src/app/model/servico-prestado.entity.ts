import { Cliente } from './cliente.entity';
import { Fornecedor } from './Fornecedor.entity';
import { TipoServico } from './tipo-servico.entity';

export interface ServicoPrestado {
    idServicoPrestado: number,
    idCliente: number,
    idFornecedor: number, 
    idTipoServico: number, 
    descricaoServicoPrestado: string, 
    dataAtendimentoServicoPrestado: Date,
    valorServicoPrestado: number,
    cliente: Cliente,
    fornecedor: Fornecedor,
    tipoServico: TipoServico,
}