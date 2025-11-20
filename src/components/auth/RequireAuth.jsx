import { Navigate } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";

export default function RequireAuth({ children }) {
  const { user } = useAuth();

  
  if (!user) {
    return <Navigate to="/login" replace />;
  }

  // Si debe cambiar la contraseña → lo forzamos a ir a esa pantalla
  if (user.debeCambiarContrasena) {
    return <Navigate to="/cambiar-contrasena" replace />;
  }

  // Puede entrar normalmente
  return children;
}
