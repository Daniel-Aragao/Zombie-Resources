import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions, Response } from '@angular/http'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Recurso } from '../entities/Recurso';

@Injectable()
export class RecursoService {
  private urlDefault = "http://localhost:49445/api/Recursos";

  constructor(private http: Http) { }

  getRecursos(): Observable<Recurso[]> {
    return this.http.get((this.urlDefault))
      .map((response: Response) => response.json() as Recurso[])
      .catch(this.handleError);
  }

  getRecurso(id): Observable<Recurso> {
    return this.http.get(this.urlDefault + "/" + id)
      .map((response: Response) => response.json() as Recurso)
      .catch(this.handleError);
  }

  addRecurso(rec: Recurso): Observable<any>{
    let bodyString = JSON.stringify(rec); 
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers, body: bodyString, method:"POST" }); 
    
    return this.http.post(this.urlDefault + '/Novo', bodyString, options) 
                    // .map(res => res.json()) 
                    .catch(this.handleError);
  }

  deleteRecurso(rec: Recurso): Observable<any>{
    return this.http.get(this.urlDefault + "/Delete/" + rec.Id)
      .map((response: Response) => response.json() as Recurso)
      .catch(this.handleError);
  }

  editRecurso(rec: Recurso): Observable<any>{
    let bodyString = JSON.stringify(rec); 
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers, body: bodyString, method:"POST" }); 
    
    return this.http.post(this.urlDefault + '/Edit', bodyString, options) 
                    // .map(res => res.json()) 
                    .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('Erro getRecursos', error);
    return Promise.reject(error.message || error);
  }
}
