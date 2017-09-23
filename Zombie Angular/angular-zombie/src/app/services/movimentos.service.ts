import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions, Response } from '@angular/http'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Movimento } from '../entities/Movimento';
import { Movimentar } from '../entities/Movimentar';

@Injectable()
export class MovimentosService {

  private urlDefault = "http://localhost:49445/api/Movimentos";

  constructor(private http: Http) { }

  getMovimentos(id: Number): Observable<Movimento[]> {
    return this.http.get(this.urlDefault + "/" + id)
      .map((response: Response) => response.json() as Movimento[])
      .catch(this.handleError);
  }

  public addMovimento(mov: Movimentar): Observable<any>{
      let bodyString = JSON.stringify(mov); 
      let headers = new Headers({ 'Content-Type': 'application/json' });
      let options = new RequestOptions({ headers: headers, body: bodyString, method:"POST" }); 
      
      return this.http.post("http://localhost:49445/api/Movimentar", bodyString, options) 
                      // .map(res => res.json()) 
                      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('Erro getMovimentos', error);
    return Promise.reject(error.message || error);
  }

}
