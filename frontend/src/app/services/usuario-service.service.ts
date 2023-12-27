import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/Usuarios';
import { Resposta } from '../models/Resposta';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService {

  private apiUrl = `${environment.baseApiUrl}/Usuario`

  constructor(private http: HttpClient) { }

  GetUsuarios() : Observable<Resposta<Usuario[]>> {
      return this.http.get<Resposta<Usuario[]>>(this.apiUrl);
  }

  GetUsuarioById(idUsuario: number) : Observable<Resposta<Usuario>> {
    console.log(`${this.apiUrl}/GetById?idUsuario=${idUsuario}`);
    return this.http.get<Resposta<Usuario>>(`${this.apiUrl}/GetById?idUsuario=${idUsuario}`);
  }

  CreateUsuario(usuario: Usuario) : Observable<Resposta<Usuario[]>> {
    return this.http.post<Resposta<Usuario[]>>(`${this.apiUrl}/New`, usuario);
  }

  EditUsuario(usuario : Usuario) : Observable<Resposta<Usuario[]>> {
      return this.http.put<Resposta<Usuario[]>>(`${this.apiUrl}/Update`, usuario); 
  }

  ChangeActiveUsuario(idUsuario: number, ativo: boolean) : Observable<Resposta<Usuario[]>>{
      const body = { 
        "idUsuario": idUsuario,
        "active": ativo
      };
      
      return this.http.put<Resposta<Usuario[]>>(`${this.apiUrl}/ChangeActive/`, body);
  }

  ExcluirUsuario(idUsuario: number) : Observable<Resposta<Usuario[]>>{
    return this.http.delete<Resposta<Usuario[]>>(`${this.apiUrl}/Delete?idUsuario=${idUsuario}`)
  }
}
