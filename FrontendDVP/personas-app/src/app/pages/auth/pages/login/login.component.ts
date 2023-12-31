import { NgForOfContext } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import * as fromRoot from '@app/store';
import * as fromUser from '@app/store/usuario';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  loading$ !: Observable<boolean | null>;
  constructor(
    private store : Store<fromRoot.State>
  ){}

  ngOnInit(): void {
    
  }

  loginUsuario(form: NgForm){
    const userLoginRequest : fromUser.NombreUsuarioPasswordCredentials ={
      nombreUsuario: form.value.nombreUsuario,
      password: form.value.password
    }
    
    this.store.dispatch(new fromUser.SingInNombreUsuario(userLoginRequest));
  }

}
