import { Action } from "@ngrx/store";
import { NombreUsuarioPasswordCredentials, UsuarioCreateRequest, UsuarioResponse } from "./usuario.models";


export enum Types{
    INIT = '[Usuario] Init: Start',
    INIT_AUTHORIZED = '[Usuario] Init:Authorized',
    INIT_UNAUTHORIZED = '[Usuaurio] Init: Unuthorized',
    INIT_ERROR = '[Usuario] Init: Error',


    SIGN_IN_NOMBREUSUARIO = '[Usuario] Login: Start',
    SIGN_IN_NOMBREUSUARIO_SUCCESS = '[Usuario] Login: Success',
    SIGN_IN_NOMBREUSUARIO_ERROR = '[Usuario] Login: Error',

    SIGN_UP_NOMBREUSUARIO = '[Usuario] Registrar usuario con NombreUsuario: Start',
    SIGN_UP_NOMBREUSUARIO_SUCCESS = '[Usuario] Registrar usuario con NombreUsuario: Success',
    SIGN_UP_NOMBREUSUARIO_ERROR = '[User] Registrar usuario con NombreUsuario: Error',

    SIGN_OUT_NOMBREUSUARIO = '[Usuario] Logout: Start',
    SIGN_OUT_NOMBREUSUARIO_SUCCESS = '[Usuario] Logout: Success',
    SIGN_OUT_NOMBREUSUARIO_ERROR = '[Usuario] Logout: Error',
}

//INIT -> EL USUARIO ESTA EN SESION?
export class Init implements Action{
    readonly type = Types.INIT;
    constructor(){}
}

export class InitAuthorized implements Action{
    readonly type = Types.INIT_AUTHORIZED;
    constructor(public NombreUsuario: string, public user: UsuarioResponse | null){}
}

export class InitUnauthorized implements Action{
    readonly type = Types.INIT_UNAUTHORIZED;
    constructor(){}
}

export class InitError implements Action{
    readonly type = Types.INIT_ERROR;
    constructor(public error: string){}
}

//LOGIN
export class SingInNombreUsuario implements Action{
    readonly type = Types.SIGN_IN_NOMBREUSUARIO;
    constructor(public credentials: NombreUsuarioPasswordCredentials){}
}

export class SingInNombreUsuarioSuccess implements Action{
    readonly type = Types.SIGN_IN_NOMBREUSUARIO_SUCCESS;
    constructor(public NombreUsuario: string, public user: UsuarioResponse){}
}

export class SingInNombreUsuarioError implements Action{
    readonly type = Types.SIGN_IN_NOMBREUSUARIO_ERROR;
    constructor(public error: string){}
}

//Sign_up
export class SignUpNombreUsuario implements Action{
    readonly type = Types.SIGN_UP_NOMBREUSUARIO;
    constructor(public user: UsuarioCreateRequest){}
}

export class SignUpNombreUsuarioSuccess implements Action{
    readonly type = Types.SIGN_UP_NOMBREUSUARIO_SUCCESS;
    constructor(public NombreUsuario: string, public user: UsuarioResponse | null){}
} 

export class SignUpNombreUsuarioError implements Action{
    readonly type = Types.SIGN_UP_NOMBREUSUARIO_ERROR;
    constructor(public error: string){}
} 

//logout
export class SignOut implements Action{
    readonly type = Types.SIGN_OUT_NOMBREUSUARIO;
    constructor(){}
}

export class SignOutSuccess implements Action{
    readonly type = Types.SIGN_OUT_NOMBREUSUARIO_SUCCESS;
    constructor(){}
}

export class SignOutError implements Action{
    readonly type = Types.SIGN_OUT_NOMBREUSUARIO_ERROR;
    constructor(public error: string){}
}

export type All =
        Init
        | InitAuthorized
        | InitUnauthorized
        | InitError
        | SingInNombreUsuario
        | SingInNombreUsuarioSuccess
        | SingInNombreUsuarioError
        | SignUpNombreUsuario
        | SignUpNombreUsuarioSuccess
        | SignUpNombreUsuarioError
        | SignOut
        | SignOutSuccess
        | SignOutError;