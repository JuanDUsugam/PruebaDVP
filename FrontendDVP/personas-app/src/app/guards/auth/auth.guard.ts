import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, CanActivateChild, CanActivateChildFn, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from "@angular/router";
import { select, Store } from "@ngrx/store";
import * as fromRoot from "@app/store";
import * as fromUser from "@app/store/usuario";
import { Observable, filter, map, tap } from "rxjs";
import { Injectable, inject } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
class PermissionsService{
    constructor(
        private router: Router,
        private store: Store<fromRoot.State>
    ){}
    
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.check();
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.check();
    }

    private check() : Observable<boolean>{
        return this.store.pipe(select(fromUser.getUserState)).pipe(
            filter(state =>  !state.loading),
            tap(state =>{
                if(!state.nombreUsuario){
                    this.router.navigate(['auth/login']);

                }
            }),
            map(state => !!state.nombreUsuario)
        )
    }
}


export const AuthGuard : CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> =>{
    return inject(PermissionsService).canActivate(route, state)
};

export const AuthGuardChild : CanActivateChildFn = (childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> =>{
    return inject(PermissionsService).canActivateChild(childRoute, state)
};