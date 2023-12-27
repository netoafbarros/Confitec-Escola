import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuarios';
import { UsuarioService } from 'src/app/services/usuario-service.service';


@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit{

  inputdata:any
  usuario!: Usuario;

  constructor(@Inject(MAT_DIALOG_DATA) public data:any, private usuarioService: UsuarioService, private router: Router, private ref:MatDialogRef<ExcluirComponent>){}

  ngOnInit(): void {    
    this.usuario = this.data;
  }

  excluir(){
    this.usuarioService.ExcluirUsuario(this.usuario.idUsuario!).subscribe(data => {
       this.ref.close();
       window.location.reload();
    });
  }

}