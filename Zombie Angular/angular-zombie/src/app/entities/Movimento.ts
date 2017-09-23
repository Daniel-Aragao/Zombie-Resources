import { Recurso } from './Recurso';

export class Movimento{
    public Id ;
    public Antes ;
    public Depois ;
    public Descricao
    public Recurso: Recurso;
    public Data: Date;
    public Responsavel;
    public TipoMovimento;

    constructor(Id,  Antes,  Depois,  Descricao, Recurso: Recurso, Data: Date, Responsavel, TipoMovimento){
    }
}