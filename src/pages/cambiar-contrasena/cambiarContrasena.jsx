import { useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import { authService } from "../../services/authService";
import { useNavigate } from "react-router-dom";

export default function CambiarContrasena() {
  const [form, setForm] = useState({ actual: "", nueva: "" });
  const { user, updateUser } = useAuth();
  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await authService.cambiarContrasena({
        idUsuario: user.idUsuario,
        contrasenaActual: form.actual,
        nuevaContrasena: form.nueva,
      });

      // Actualizamos el user en contexto
      updateUser({ ...user, CambiarContrasena: false });

      alert("Contraseña cambiada correctamente.");
      navigate("/dashboard");

    } catch (err) {
      console.error(err);
      alert("Error al cambiar la contraseña.");
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <form
        onSubmit={handleSubmit}
        className="bg-white p-6 rounded shadow w-full max-w-md"
      >
        <h2 className="text-2xl font-bold mb-4">Cambiar Contraseña</h2>

        <input
          type="password"
          name="actual"
          placeholder="Contraseña actual"
          onChange={handleChange}
          className="w-full p-2 border rounded mb-3"
        />

        <input
          type="password"
          name="nueva"
          placeholder="Nueva contraseña"
          onChange={handleChange}
          className="w-full p-2 border rounded mb-4"
        />

        <button className="w-full bg-blue-600 text-white py-2 rounded">
          Actualizar
        </button>
      </form>
    </div>
  );
}
