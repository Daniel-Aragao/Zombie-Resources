import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params,  } from '@angular/router';
import { MovimentosService } from '../../services/movimentos.service';
import { RecursoService } from '../../services/recurso.service';

import { Recurso } from '../../entities/Recurso';
import { Movimento } from '../../entities/Movimento';
import { Movimentar } from '../../entities/Movimentar';
import { Usuario } from '../../entities/Usuario';

@Component({
  selector: 'app-movimentos',
  templateUrl: './movimentos.component.html',
  styleUrls: ['./movimentos.component.css']
})
export class MovimentosComponent implements OnInit {
  private id: number;
  private Movimentos: Movimento[] = [];
  private Recurso: Recurso;
  private isEdicao: boolean = false;
  private Movimentar: Movimentar;
  
  constructor(private route: ActivatedRoute, 
    private movimentosService :MovimentosService,
    private recursoService: RecursoService) { }

  ngOnInit() {
    this.route.params.subscribe((p: Params) => this.id = p['id'])
    this.getMovimentos();
    this.getRecurso();
  }

  getMovimentos(){
    this.movimentosService.getMovimentos(this.id)
    .subscribe((mov: Movimento[]) => this.Movimentos = mov,
      error => console.log(<any>error));
  }

  getRecurso(){
    this.recursoService.getRecurso(this.id)
    .subscribe((rec: Recurso) => this.Recurso = rec,
      error => console.log(<any>error));
  }
  movimentar(){
    if(!this.isEdicao){
      this.editMode();    
    }else{
      this.confirmMovement();
    }
  }
  confirmMovement(){
    this.movimentosService.addMovimento(this.Movimentar)
      .subscribe((response)=> this.reload(response), error => this.erro(error));
  }
  erro(error){
    console.log(error);
    let msg = "";
    try{
      let msgs = JSON.parse(JSON.parse(error._body).Message);
      for(let m in msgs){
        if(msgs[m]){
          msg += msgs[m].Value + ";\n";
        }
      }
    }catch(e){
      msg = JSON.parse(error._body).Message 
    }
    alert(msg)
  }
  reload(response){
    this.cancelEdit();
    this.getMovimentos();
    this.getRecurso();
  }
  editMode(){
    this.isEdicao = true;
    this.Movimentar = new Movimentar(
      this.Recurso.Id,
      0,
      '',
      new Usuario("","")
    );
  }
  cancelEdit(){
    this.Movimentar = null;
    this.isEdicao = false;    
  }

}
