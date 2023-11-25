import {createSelector, createFeatureSelector} from '@ngrx/store';
import { UsuarioState } from './usuario.reducer';

export const getUserState = createFeatureSelector<UsuarioState>('user');

export const getUser = createSelector(
    getUserState,
    (state) => state.entity
)

export const getLoading = createSelector(
    getUserState,
    (state) => state.loading
)

export const getIsAuthorized = createSelector(
    getUserState,
    (state) => !!state.nombreUsuario
)

