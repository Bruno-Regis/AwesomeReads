export interface LoginUsuarioRequest {
  email: string;
  senha: string;
  role: string;
}

export interface LoginResponse {
  token: string;
}
