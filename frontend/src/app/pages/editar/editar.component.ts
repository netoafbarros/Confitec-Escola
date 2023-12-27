import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuarios';
import { UsuarioService } from 'src/app/services/usuario-service.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit{

  btnAcao = "Editar";
  btnTitulo = "Editar Usuário";
  usuario!: Usuario;

  constructor(private usuarioService : UsuarioService, private router :Router,  private route : ActivatedRoute) {

  }

  ngOnInit(): void {
    const idUsuario = Number(this.route.snapshot.paramMap.get('idUsuario'));
    this.usuarioService.GetUsuarioById(idUsuario).subscribe((data) => {
        this.usuario = data.result;
    });
  }

  async editUsuario(usuario : Usuario){
    console.log('usuario:', usuario);
      this.usuarioService.EditUsuario(usuario).subscribe(data => {
        this.router.navigate(['/']);
      });

  }

}
