import { ActionReducerMap } from "@ngrx/store";
import * as fromUser from './usuario';

export interface State{
    user: fromUser.UsuarioState;
}

export const reducers: ActionReducerMap<State> ={
    user: fromUser.reducer
}

export const effects = [
    fromUser.UserEffects
]
