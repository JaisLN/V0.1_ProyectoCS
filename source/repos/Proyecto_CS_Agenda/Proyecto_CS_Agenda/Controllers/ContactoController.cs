using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Controllers
{
    public class ContactoController
    {
        private readonly ConstSoft_agendaContext _context;

        public ContactoController(ConstSoft_agendaContext context)
        {
            _context = context;
        }

        // Obtener todos los contactos
        public List<Contacto> ObtenerTodosContactos()
        {
            return _context.Contactos.ToList();
        }

        // Obtener un contacto por ID
        public Contacto ObtenerContactoPorId(int id)
        {
            try
            {
                return _context.Contactos.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el contacto por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo contacto
        public void AgregarContacto(Contacto nuevoContacto)
        {
            try
            {
                _context.Contactos.Add(nuevoContacto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el contacto: {ex.Message}");
            }
        }

        // Eliminar un contacto por ID
        public void EliminarContacto(int id)
        {
            try
            {
                var contactoAEliminar = _context.Contactos.Find(id);

                if (contactoAEliminar != null)
                {
                    _context.Contactos.Remove(contactoAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el contacto: {ex.Message}");
            }
        }

        // Editar un contacto por ID
        public void EditarContacto(int id, Contacto contactoEditado)
        {
            try
            {
                if (id != contactoEditado.Id)
                {
                    throw new InvalidOperationException("ID del contacto no coincide");
                }

                _context.Entry(contactoEditado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el contacto: {ex.Message}");
            }
        }
    }
}

