import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario-service.service';
import { Usuario } from '../../models/Usuarios';
import { ExcluirComponent } from '../../components/excluir/excluir.component'
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  usuarios: Usuario[] = [];
  usuariosGeral: Usuario[] = [];
  columnsToDisplay = ['Situacao', 'Nome', 'Sobrenome', 'Email', 'Acoes', 'Teste'];


  constructor(private usuarioService : UsuarioService, public matDialog: MatDialog) { }


  ngOnInit(): void {
    this.usuarioService.GetUsuarios().subscribe((data) => {
      const dados = data.result;
       dados.map((item) => {
         item.dataNascimento = new Date(item.dataNascimento!).toLocaleDateString('pt-BR');
       });

      this.usuariosGeral = dados;
      this.usuarios = dados;

    })
  }

  search(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.usuarios = this.usuariosGeral.filter(usuario => {
      return usuario.nome.toLowerCase().includes(value);
    })
  }

  openDialog(data : Usuario){
    this.matDialog.open(ExcluirComponent,{
      width: '350px',
      height: '350px',
      data: data
    })
  }


}



