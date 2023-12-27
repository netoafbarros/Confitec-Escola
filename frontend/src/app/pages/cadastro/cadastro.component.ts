import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuarios';
import { UsuarioService } from 'src/app/services/usuario-service.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  btnAcao = "Cadastrar!";
  btnTitulo = "Cadastrar Usuário!";

  constructor(private usuarioService : UsuarioService, private router: Router) {
  }

  ngOnInit(): void {
  }

  createUsuario(usuario: Usuario){
       this.usuarioService.CreateUsuario(usuario).subscribe((data) => {
          this.router.navigate(['/']);
       })
  }
}
