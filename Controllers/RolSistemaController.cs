using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CS_Agenda.Controllers
{
    /// <summary>
    /// Controlador para los metodos de la clase RolSistema
    /// </summary>
    internal class RolSistemaController
    {
        private readonly p1ConstSoftContext _context;

        public RolSistemaController(p1ConstSoftContext context)
        {
            _context = context;
        }

        // Obtener todos los roles del sistema

        /// <summary>
        /// Metodo para obtener los Roles de la tabla RolSistema_
        /// </summary>
        /// <returns>Retorna en una lista todos los rows encontrados en la BD
        /// respecto a la tabla</returns>
        public List<RolSistema> ObtenerTodosRoles()
        {
            return _context.RolSistemas.ToList();
        }

        // Agregar un nuevo rol del sistema
        public void AgregarRol(RolSistema nuevoRol)
        {
            _context.RolSistemas.Add(nuevoRol);
            _context.SaveChanges();
        }

        // Eliminar un rol del sistema por ID
        public void EliminarRol(string id)
        {
            var rolAEliminar = _context.RolSistemas.Find(id);

            if (rolAEliminar != null)
            {
                _context.RolSistemas.Remove(rolAEliminar);
                _context.SaveChanges();
            }
        }

        // Editar un rol del sistema por ID
        public void EditarRol(string id, RolSistema rolEditado)
        {
            if (id != rolEditado.Id)
            {
                throw new InvalidOperationException("ID del rol no coincide");
            }

            _context.Entry(rolEditado).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
