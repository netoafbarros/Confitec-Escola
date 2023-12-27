import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Escolaridade } from '../models/Escolaridade';
import { Resposta } from '../models/Resposta';

@Injectable({
  providedIn: 'root'
})

export class EscolaridadeService {

  private apiUrl = `${environment.baseApiUrl}/Escolaridade`

  constructor(private http: HttpClient) { }

  GetAll() : Observable<Resposta<Escolaridade[]>> {
      return this.http.get<Resposta<Escolaridade[]>>(this.apiUrl);
  }

}
