// src/components/layout/DashboardLayout.jsx
import { Outlet } from "react-router-dom";

export default function DashboardLayout() {
  return (
    <div className="min-h-screen flex">
      <aside className="w-64 bg-gray-800 text-white p-4">Sidebar (menu)</aside>
      <div className="flex-1">
        <header className="bg-white p-4 shadow">Navbar</header>
        <main className="p-6">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
