import { createBrowserRouter } from "react-router-dom";
import Login from "../pages/login/Login";
import Dashboard from "../pages/Dashboard/Dashboard";
import DashboardLayout from "../components/layout/DashboardLayout";
import RequireAuth from "../components/auth/RequireAuth";
import CambiarContrasena from "../pages/cambiar-contrasena/CambiarContrasena";


export const router = createBrowserRouter([
  {
    path: "/",
    element: <Login />,
  },
  {
    path: "/dashboard",
    element: (
      <RequireAuth roles={["Admin", "Profesor", "Alumno"]}>
        <DashboardLayout />
      </RequireAuth>
    ),
    children: [
      { index: true, element: <Dashboard /> },
    ],
  },
  {
    path: "/cambiar-contrasena",
    element: <CambiarContrasena />,
  },
]);
