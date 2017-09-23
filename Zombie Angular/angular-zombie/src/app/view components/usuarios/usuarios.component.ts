import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../entities/Usuario';

import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  private Usuario: Usuario;

  constructor(private usuarioService: UsuarioService) { 
    this.Usuario = new Usuario("", "");
  }

  ngOnInit() {

  }

  salvar(){
    let user = this.Usuario;
    this.Usuario = new Usuario("", "");
    this.usuarioService.addUsuario(user)
      .subscribe((value)=> alert("Usuário(a) \""+user.Nome+"\" registrado(a) com sucesso"),
        error => this.erro(error));
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
}
