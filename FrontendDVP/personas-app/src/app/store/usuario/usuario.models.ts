import { Usuario } from '@app/models/backend/usuario';

export { Usuario as UsuarioResponse} from '@app/models/backend/usuario';


export interface NombreUsuarioPasswordCredentials{
    email: string;
    password: string;
}

export interface UsuarioRequest extends Usuario{
    password: string;
}

export type UsuarioCreateRequest = Omit<UsuarioRequest, 'token' | 'id'>; 