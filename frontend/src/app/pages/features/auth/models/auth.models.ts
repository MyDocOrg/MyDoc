export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    status: number;
    mensaje: string;
    data: string; // JWT token
}

export interface DecodedToken {
    id: string;
    email: string;
    roleId: string;
    roleName: string;
    applicationId: string;
    applicationName: string;
    patientId?: string;
    exp: number;
    iss: string;
    aud: string;
}

export interface User {
    id: string;
    email: string;
    roleId: string;
    roleName: string;
    applicationId: string;
    applicationName: string;
    patientId?: string;
}
