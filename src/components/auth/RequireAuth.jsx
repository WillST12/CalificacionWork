import { Navigate } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";

export default function RequireAuth({ children, roles }) {
  const { user } = useAuth();

  if (!user) return <Navigate to="/" replace />;

  if (roles && roles.length > 0) {
    const userRol = user.rol ?? user.role ?? user.rolName;
    if (!roles.includes(userRol)) return <Navigate to="/" replace />;
  }

  return children;
}
