import { Persona } from "@app/models/backend/persona";
export { Persona as PersonaResponse } from "@app/models/backend/persona";

export type PersonaCreateRequest = Omit<Persona, 'id'>;

export interface PersonaCreateResponse{
    id : string;
}