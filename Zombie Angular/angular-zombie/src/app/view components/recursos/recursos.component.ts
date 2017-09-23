import { Component, OnInit } from '@angular/core';
import { Recurso } from '../../entities/Recurso';

import { RecursoService } from '../../services/recurso.service';

@Component({
  selector: 'app-recursos',
  templateUrl: './recursos.component.html',
  styleUrls: ['./recursos.component.css']
})
export class RecursosComponent implements OnInit {
  private isAdicionando: boolean = false;
  private isEditando: boolean = false;
  private Recursos: Recurso[];
  private Recurso: Recurso;

  private Filtro: String = "";
  private FiltroArray: boolean[] = [];

  constructor(private recursoService: RecursoService) {
    console.log('RecursosComponent')
    this.Recurso = new Recurso('','','','');
   }

  ngOnInit() {
    this.getRecursos();
  }

  getRecursos(){
    this.recursoService.getRecursos()
      .subscribe((rec: Recurso[]) => {
        this.Recursos = rec
        this.Filtrar();
      },
        error => console.log(<any>error));
  }

  addMode(){
    this.isEditando = false;
    this.isAdicionando = true;
    this.Recurso = new Recurso('','','','');
  }

  adicionar(){
    if(!this.isAdicionando && !this.isEditando){
      this.addMode();    
    }else if(!this.isEditando){
      this.confirmAdicao();
    }else{
      this.confirmEdicao();
    }
  }
  
  confirmAdicao(){
    let rec = this.Recurso;
    
    this.recursoService.addRecurso(rec)
      .subscribe((response) => this.reload(response),
          error => this.erro(error));
  }

  reload(response){
    this.cancelEdit();
    this.getRecursos();
  }

  cancelEdit(){
    this.Recurso = new Recurso('','','','');    
    this.isAdicionando = false;
    this.isEditando = false;
  }

  erro(error){
    console.log(error);
    let msg = "";
    try{
      let msgs = JSON.parse(JSON.parse(error._body).Message);
      for(let m in msgs){
        if(msgs[m]){
          msg += msgs[m].Value + ".\n";
        }
      }
    }catch(e){
      msg = JSON.parse(error._body).Message 
    }
    alert(msg)
  }

  remover(rec: Recurso){
    let answer = confirm("Confirmar exclusão do recurso: \"" + rec.Descricao + "\"?");
    if(answer){
      this.recursoService.deleteRecurso(rec)
        .subscribe(response => this.reload(response), error => this.erro(error));
    }
  }

  editar(rec: Recurso){
    this.Recurso = rec;
    this.isEditando = true;
    this.isAdicionando = false;
  }

  confirmEdicao(){
    let rec = this.Recurso;
    
    this.recursoService.editRecurso(rec)
      .subscribe((response) => this.reload(response),
          error => this.erro(error));
  }

  Contains(recurso: Recurso){
    let contain = recurso.Descricao.toLowerCase().indexOf(this.Filtro.toLowerCase()) + 1;
    contain += recurso.Observacao.toLowerCase().indexOf(this.Filtro.toLowerCase()) + 1;
    return !!contain;
  }

  Filtrar(){
    this.Recursos.forEach((r, i)=>{
      this.FiltroArray[r.Id] = this.Contains(r);
    });
  }
}
