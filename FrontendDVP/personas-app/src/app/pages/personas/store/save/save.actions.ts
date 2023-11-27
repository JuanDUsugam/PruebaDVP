import { Action } from "@ngrx/store";
import { PersonaCreateRequest, PersonaCreateResponse, PersonaResponse } from "./save.models";

export enum Types{
    CREATE = '[Persona] Create: Start',
    CREATE_SUCCESS = '[Persona] Create: Success',
    CREATE_ERROR = '[Persona] Create: Error',

    READ = '[Persona] Read',
    READ_SUCCESS = '[Persona] Read: Success',
    READ_ERROR = '[Persona] Read : Error',
}

export class Read implements Action{
    readonly type = Types.READ;
    constructor(){}
}

export class ReadSuccess implements Action{
    readonly type = Types.READ_SUCCESS;
    constructor(public personas : PersonaResponse[]){}
}

export class ReadError implements Action{
    readonly type = Types.READ_SUCCESS;
    constructor(public error : string){}
}

export class Create implements Action{
    readonly type = Types.CREATE;
    constructor(public persona: PersonaCreateRequest){}
}

export class CreateSuccess implements Action{
    readonly type = Types.CREATE_SUCCESS;
    constructor(public persona: PersonaCreateResponse){}
}

export class CreateError implements Action{
    readonly type = Types.CREATE_ERROR;
    constructor(public error : string){}
}

export type All = Create | CreateSuccess | CreateError | CreateError | Read | ReadSuccess | ReadError;