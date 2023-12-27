import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario-service.service';
import { Usuario } from 'src/app/models/Usuarios';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent implements OnInit{

   usuario?: Usuario;
   idUsuario!:number;

  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router : Router) {

  }

  ngOnInit(): void {

      this.idUsuario =  Number(this.route.snapshot.paramMap.get("idUsuario"));

      this.usuarioService.GetUsuarioById( this.idUsuario).subscribe((data) => {
         const dados = data.result;
         dados.dataNascimento = new Date(dados.dataNascimento!).toLocaleDateString("pt-BR");

         this.usuario = dados;
      });
  }

  ChangeActiveUsuario(){

      this.usuarioService.ChangeActiveUsuario(this.idUsuario, !this.usuario?.ativo).subscribe((data) => {
        this.router.navigate(['']);
        }
      );

  }
}
