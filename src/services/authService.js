// src/services/authService.js
import { api } from "./api";

export const authService = {
  login: async (payload) => {
   
    const body = {
      NombreUsuario: payload.nombreUsuario ?? payload.user ?? payload.username,
      Contrasena: payload.contrasena ?? payload.password ?? payload.pass
    };

    const res = await api.post("/auth/login", body);
    return res.data;
  },
};
