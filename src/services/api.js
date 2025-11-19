
import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7055/api", 

});

api.interceptors.request.use((config) => {
  const saved = localStorage.getItem("user");
  if (saved) {
    const user = JSON.parse(saved);
    if (user.token) config.headers.Authorization = `Bearer ${user.token}`;
  }
  return config;
});
