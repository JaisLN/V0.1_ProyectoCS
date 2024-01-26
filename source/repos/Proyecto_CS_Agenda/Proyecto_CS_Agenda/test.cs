/*using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CS_Agenda
{
    internal class test
    {
        static void Main(string[] args)
        {
            // Crea una instancia del contexto de la base de datos
            using (var context = new p1ConstSoftContext())
            {
                // Crea una instancia del controlador de RolSistema
                var rolController = new RolSistemaController(context);

                // Agrega dos nuevos roles
                rolController.AgregarRol(new RolSistema { Id = "1", Nombre = "Admin", Estado = "Activo" });
                rolController.AgregarRol(new RolSistema { Id = "2", Nombre = "Usuario", Estado = "Activo" });

                // Lista todos los roles
                Console.WriteLine("Roles existentes:");
                var roles = rolController.ObtenerTodosRoles();
                foreach (var rol in roles)
                {
                    Console.WriteLine($"ID: {rol.Id}, Nombre: {rol.Nombre}, Estado: {rol.Estado}");
                }

                // Edita un rol (por ejemplo, cambia el estado del rol "1")
                var rolAEditar = roles.FirstOrDefault(r => r.Id == "1");
                if (rolAEditar != null)
                {
                    rolAEditar.Estado = "Inactivo";
                    rolController.EditarRol(rolAEditar.Id, rolAEditar);
                }

                // Lista los roles después de la edición
                Console.WriteLine("\nRoles después de la edición:");
                var rolesDespuesEdicion = rolController.ObtenerTodosRoles();
                foreach (var rol in rolesDespuesEdicion)
                {
                    Console.WriteLine($"ID: {rol.Id}, Nombre: {rol.Nombre}, Estado: {rol.Estado}");
                }

                // Elimina un rol (por ejemplo, elimina el rol "2")
                var idRolAEliminar = "2";
                rolController.EliminarRol(idRolAEliminar);

                // Lista los roles después de la eliminación
                Console.WriteLine("\nRoles después de la eliminación:");
                var rolesDespuesEliminacion = rolController.ObtenerTodosRoles();
                foreach (var rol in rolesDespuesEliminacion)
                {
                    Console.WriteLine($"ID: {rol.Id}, Nombre: {rol.Nombre}, Estado: {rol.Estado}");
                }
            }
        }
    }
}*/