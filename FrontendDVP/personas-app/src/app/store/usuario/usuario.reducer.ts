import { UsuarioResponse } from "./usuario.models";
import * as fromActions from './usuario.actions';

export interface UsuarioState{
    entity: UsuarioResponse| null;
    id : string | null;
    nombreUsuario: string | null;
    loading: boolean | null;
    error: string | null;
}

const initialState : UsuarioState ={
    entity: null,
    id : null,
    nombreUsuario: null,
    loading:  null,
    error: null
}

export function reducer(state = initialState, action : fromActions.All | any) : UsuarioState{

    switch(action.type){
        //init
        case fromActions.Types.INIT:{
            return { ...state, loading: true};
        }
        case fromActions.Types.INIT_AUTHORIZED:{
            return { ...state, loading: false, entity: action.user, nombreUsuario : action.user, error: null};
        }
        case fromActions.Types.INIT_UNAUTHORIZED:{
            return { ...state, loading: false, entity: null, nombreUsuario : null, error: null};
        }
        case fromActions.Types.INIT_ERROR:{
            return { ...state, loading: false, entity: null, nombreUsuario : null, error: action.error};
        }
        //login
        case fromActions.Types.SIGN_IN_NOMBREUSUARIO:{
            return { ...state, loading: true, entity: null, nombreUsuario :null, error: null};
        }
        case fromActions.Types.SIGN_IN_NOMBREUSUARIO_SUCCESS:{
            return { ...state, loading: false, entity: action.user, nombreUsuario :action.user, error: null};
        }
        case fromActions.Types.SIGN_IN_NOMBREUSUARIO_ERROR:{
            return { ...state, loading: false, entity: null, nombreUsuario :null, error: action.error};
        }
        //registro de usuarios
        case fromActions.Types.SIGN_UP_NOMBREUSUARIO:{
            return { ...state, loading: true, entity: null, nombreUsuario :null, error: null};
        }
        case fromActions.Types.SIGN_UP_NOMBREUSUARIO_SUCCESS:{
            return { ...state, loading: false, entity: action.user, nombreUsuario :action.user, error: null};
        }
        case fromActions.Types.SIGN_UP_NOMBREUSUARIO_ERROR:{
            return { ...state, loading: false, entity: null, nombreUsuario :null, error: action.error};
        }
        //logout
        case fromActions.Types.SIGN_OUT_NOMBREUSUARIO:{
            return {...initialState};
        }
        case fromActions.Types.SIGN_OUT_NOMBREUSUARIO_SUCCESS:{
            return { ...initialState};
        }
        case fromActions.Types.SIGN_OUT_NOMBREUSUARIO_ERROR:{
            return { ...state, loading: false, entity: null, nombreUsuario :null, error: action.error};
        }
        default:
            return state;
    }
}