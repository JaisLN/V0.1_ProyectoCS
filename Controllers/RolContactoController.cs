using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Controllers
{
    public class RolContactoController
    {
        private readonly p1ConstSoftContext _context;

        public RolContactoController(p1ConstSoftContext context)
        {
            _context = context;
        }

        // Obtener todos los roles de contacto
        public List<RolContacto> ObtenerTodosRolesContacto()
        {
            return _context.RolContactos.ToList();
        }

        // Obtener un rol de contacto por ID
        public RolContacto ObtenerRolContactoPorId(string id)
        {
            try
            {
                return _context.RolContactos.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el rol de contacto por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo rol de contacto
        public void AgregarRolContacto(RolContacto nuevoRolContacto)
        {
            try
            {
                _context.RolContactos.Add(nuevoRolContacto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el rol de contacto: {ex.Message}");
            }
        }

        // Eliminar un rol de contacto por ID
        public void EliminarRolContacto(string id)
        {
            try
            {
                var rolContactoAEliminar = _context.RolContactos.Find(id);

                if (rolContactoAEliminar != null)
                {
                    _context.RolContactos.Remove(rolContactoAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol de contacto: {ex.Message}");
            }
        }

        // Editar un rol de contacto por ID
        public void EditarRolContacto(string id, RolContacto rolContactoEditado)
        {
            try
            {
                if (id != rolContactoEditado.Id)
                {
                    throw new InvalidOperationException("ID del rol de contacto no coincide");
                }

                _context.Entry(rolContactoEditado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el rol de contacto: {ex.Message}");
            }
        }
    }
}
