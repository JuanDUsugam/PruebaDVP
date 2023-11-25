import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { NotificationService } from "@app/services";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { environment } from "@src/environments/environment";
import { Observable, of } from "rxjs";
import { catchError, switchMap, tap, map } from "rxjs/operators";
import * as fromActions from './usuario.actions';
import { UsuarioResponse } from "./usuario.models";

type Action = fromActions.All;

@Injectable()
export class UserEffects{

    constructor(
        private httpClient: HttpClient,
        private actions: Actions,
        private notification: NotificationService,
        private router : Router
    ){

    }

    signUpEmail: Observable<Action> = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.Types.SIGN_UP_NOMBREUSUARIO),
            map((action: fromActions.SignUpNombreUsuario)=> action.user),
            switchMap( userData => 
                    this.httpClient.post<UsuarioResponse>(`${environment.url}api/Usuario/Registrar`, userData)
                    .pipe(
                        tap((response: UsuarioResponse) => {
                            localStorage.setItem('token', response.token);
                            this.router.navigate(['/']);
                        }), 
                        map((response : UsuarioResponse)=> new fromActions.SignUpNombreUsuarioSuccess(response.nombreUsuario, response || null)),
                        catchError(err =>{
                            this.notification.error("Errores al registrar un nuevo usuario");
                            return of(new fromActions.SignUpNombreUsuarioError(err.message));
                        })
                    )
                )
        )
    );

    signInEmail: Observable<Action> = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.Types.SIGN_IN_NOMBREUSUARIO),
            map((action: fromActions.SingInNombreUsuario)=> action.credentials),
            switchMap( userData => 
                    this.httpClient.post<UsuarioResponse>(`${environment.url}api/Usuario/Login`, userData)
                    .pipe(
                        tap((response: UsuarioResponse) => {
                            localStorage.setItem('token', response.token);
                            this.router.navigate(['/']);
                            
                        }), 
                        map((response : UsuarioResponse)=> new fromActions.SingInNombreUsuarioSuccess(response.nombreUsuario, response || null)),
                        catchError(err =>{
                            console.log(userData);
                            this.notification.error("Las Credenciales son incorrectas");
                            return of(new fromActions.SingInNombreUsuarioError(err.message));
                        })
                    )
                )
        )
    );

    init: Observable<Action> = createEffect(() =>
        this.actions.pipe(
            ofType(fromActions.Types.INIT),
            switchMap(async () =>  localStorage.getItem('token')),
            switchMap( token =>{
                if(token){
                    return this.httpClient.get<UsuarioResponse>(`${environment.url}api/Usuario`)
                    .pipe(
                        tap((response: UsuarioResponse) => {
                            console.log('data erronea del usuarion en sesion que viene del servidor', response)
                        }), 
                        map((response : UsuarioResponse)=> new fromActions.InitAuthorized(response.nombreUsuario, response || null)),
                        catchError(err =>{
                            return of(new fromActions.InitError(err.message));
                        })
                    )
                }else{
                    return of(new fromActions.InitUnauthorized());
                }
                
            } 
                    
                )
        )
    );
}