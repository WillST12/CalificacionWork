import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7055/api", // ajusta si tu backend corre en otro puerto
});

api.interceptors.request.use((config) => {
  const savedUser = localStorage.getItem("user");
  if (savedUser) {
    const user = JSON.parse(savedUser);
    if (user.token) config.headers.Authorization = `Bearer ${user.token}`;
  }
  return config;
});
