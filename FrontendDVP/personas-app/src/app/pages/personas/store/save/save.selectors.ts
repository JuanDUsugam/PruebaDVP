import { createSelector } from "@ngrx/store";
import { getPersonaState, PersonaState } from '../index';

import { ListState } from "./save.reducer";

export const getListState = createSelector(
    getPersonaState,
    (state: PersonaState) => state.list
)

export const getLoading = createSelector(
    getListState,
    (state: ListState) => state.loading
)

export const getPersonas = createSelector(
    getListState,
    (state: ListState) => state.personas
)