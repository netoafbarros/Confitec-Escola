import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { Router } from '@angular/router';
import { Escolaridade } from 'src/app/models/Escolaridade';
import { Usuario } from 'src/app/models/Usuarios';
import { EscolaridadeService } from 'src/app/services/escolaridade.service';
import { UsuarioService } from 'src/app/services/usuario-service.service';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
  styleUrls: ['./usuario-form.component.css'],
})

export class UsuarioFormComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Usuario>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input()  dadosUsuario?: Usuario;

  escolaridades : Escolaridade[] = [];
  usuarioForm!: FormGroup;
  ativo:number = 1;


  constructor(private escolaridadeService : EscolaridadeService, private router: Router) {
  }

  ngOnInit(): void {

    this.usuarioForm = new FormGroup ({
      idUsuario: new FormControl(this.dadosUsuario ? this.dadosUsuario.idUsuario : 0),
      nome: new FormControl(this.dadosUsuario ? this.dadosUsuario.nome : '', [Validators.required]),
      sobrenome: new FormControl(this.dadosUsuario ? this.dadosUsuario.sobrenome : '',[Validators.required]),
      email: new FormControl(this.dadosUsuario ? this.dadosUsuario.email : '',[Validators.required]),
      dataNascimento: new FormControl(this.dadosUsuario ? this.dadosUsuario.dataNascimento : new Date()),
      idEscolaridade: new FormControl(this.dadosUsuario ? this.dadosUsuario.idEscolaridade : '',[Validators.required]),
      ativo:  new FormControl(this.dadosUsuario ? this.dadosUsuario?.ativo : true)
    });

    this.escolaridadeService.GetAll().subscribe((data) => {
      this.escolaridades = data.result;
    })

  }

  get nome(){
    return this.usuarioForm.get('nome')!;
  }

  submit(){

      console.log(this.usuarioForm.value)

      this.onSubmit.emit(this.usuarioForm.value);
  }

}
