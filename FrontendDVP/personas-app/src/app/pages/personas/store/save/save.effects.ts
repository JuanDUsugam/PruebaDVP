import { Injectable } from "@angular/core";
import * as fromActions from "./save.actions";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { NotificationService } from "@app/services";
import { catchError, delay, map, switchMap, tap } from "rxjs/operators";
import { Observable, of } from "rxjs";
import { PersonaCreateRequest, PersonaCreateResponse, PersonaResponse } from "./save.models";
import { environment } from "environments/environment";

type Action = fromActions.All;

@Injectable()
export class SaveEffecs{

    constructor(
        private actions: Actions,
        private http : HttpClient,
        private router : Router,
        private notification : NotificationService
    ){}

    read : Observable<Action> = createEffect(() =>
             this.actions.pipe(
                ofType(fromActions.Types.READ),
                switchMap(() =>
                    this.http.get<PersonaResponse[]>(`${environment.url}api/Personas`)
                    .pipe(
                        delay(1000),
                        map((personas: PersonaResponse[]) => new fromActions.ReadSuccess(personas)),
                        catchError(err => of(new fromActions.ReadError(err.message)))
                    )
                )
            )
        );

        create : Observable<Action> = createEffect(() =>
        this.actions.pipe(
           ofType(fromActions.Types.CREATE),
           map((action: fromActions.Create) => action.persona),
           switchMap((request: PersonaCreateRequest) =>
               this.http.post<PersonaCreateResponse>(`${environment.url}api/Personas/Crear`, request)
               .pipe(
                   delay(1000),
                   tap((response: PersonaCreateResponse)=>{
                    this.router.navigate(['/persona/list']);
                   }),
                   map((persona: PersonaCreateResponse) => new fromActions.CreateSuccess(persona)),
                   catchError(err => {
                    this.notification.error(`Errores guardando la persona: ${err.message}`);
                    
                    return of(new fromActions.CreateError(err.message));
                    })
               )
           )
       )
    );
}
