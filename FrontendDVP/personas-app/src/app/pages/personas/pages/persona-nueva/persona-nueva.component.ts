import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Store, compose, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromRoot from '@app/store';
import * as fromList from '../../store/save';

@Component({
  selector: 'app-persona-nueva',
  templateUrl: './persona-nueva.component.html',
  styleUrls: ['./persona-nueva.component.scss']
})
export class PersonaNuevaComponent implements OnInit{
  loading$ !: Observable<boolean | null>;
  

  constructor(
    private store: Store<fromRoot.State>
  ){}
  ngOnInit(): void {}
  
  registrarPersona(form: NgForm) : void{
    if(form.valid){
      this.loading$ = this.store.pipe(select(fromList.getLoading));

      const personaCreateRequest : fromList.PersonaCreateRequest ={
        nombres: form.value.nombres,
        apellidos : form.value.apellidos,
        numeroIdentificacion: Number(form.value.numeroIdentificacion),
        email: form.value.email,
        tipoIdentificacion: form.value.tipoIdentificacion
      }

      
      this.store.dispatch(new fromList.Create(personaCreateRequest));
    }
  }

  

}
