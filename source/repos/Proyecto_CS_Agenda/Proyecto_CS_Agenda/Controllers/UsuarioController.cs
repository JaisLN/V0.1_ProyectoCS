using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CS_Agenda.Controllers
{
    public class UsuarioController
    {
        private readonly ConstSoft_agendaContext _context;

        public UsuarioController(ConstSoft_agendaContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerTodosUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        // Obtener un usuario por ID
        public Usuario ObtenerUsuarioPorId(int id)
        {
            try
            {
                return _context.Usuarios.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo usuario
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            try
            {
                _context.Usuarios.Add(nuevoUsuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el usuario: {ex.Message}");
            }
        }

        // Eliminar un usuario por ID
        public void EliminarUsuario(int id)
        {
            try
            {
                var usuarioAEliminar = _context.Usuarios.Find(id);

                if (usuarioAEliminar != null)
                {
                    _context.Usuarios.Remove(usuarioAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
            }
        }

        // Editar un usuario por ID
        public void EditarUsuario(int id, Usuario usuarioEditado)
        {
            try
            {
                if (id != usuarioEditado.Id)
                {
                    throw new InvalidOperationException("ID del usuario no coincide");
                }

                _context.Entry(usuarioEditado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el usuario: {ex.Message}");
            }
        }

        //obtener por Username
        public Usuario ObtenerUsuarioporUsername(string username)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Username == username);
        }

        //obtener por Cedula
        public Usuario ObtenerUsuarioByCI(string Ci)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Cedula == Ci);
        }
    }
}