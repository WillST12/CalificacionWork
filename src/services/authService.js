import { api } from "./api";

export const authService = {
  login: async (credentials) => {
    const res = await api.post("/auth/login", credentials);
    return res.data;
  },

};
