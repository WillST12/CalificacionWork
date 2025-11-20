import { api } from "./axiosConfig";

export const authService = {
  login: async (credentials) => {
    const { data } = await api.post("/auth/login", credentials);
    return data;
  },

  cambiarPassword: async (payload) => {
    const { data } = await api.post("/auth/cambiar-contrasena", payload);
    return data;
  }
};
