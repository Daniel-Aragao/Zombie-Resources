import { Usuario } from './Usuario';

export class Movimentar{
    /**
     *
     */
    constructor(public RecursoId, public Quantidade, public Descricao, public Usuario: Usuario) {
        
    }
}