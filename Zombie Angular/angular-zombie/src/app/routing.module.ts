import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RecursosComponent } from './view components/recursos/recursos.component';
import { UsuariosComponent } from './view components/usuarios/usuarios.component';
import { MovimentosComponent } from './view components/movimentos/movimentos.component';

const routes: Routes = [
  { path: '', redirectTo: '/recursos', pathMatch: 'full' },
  { path: 'recursos', component: RecursosComponent },
  { path: 'movimentos/:id', component: MovimentosComponent },
  { path: 'usuarios', component: UsuariosComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
    
export class RoutingModule {}