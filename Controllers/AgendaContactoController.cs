using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Controllers
{
    public class AgendaContactoController
    {
        private readonly p1ConstSoftContext _context;

        public AgendaContactoController(p1ConstSoftContext context)
        {
            _context = context;
        }

        // Obtener todos los contactos de la agenda
        public List<AgendaContacto> ObtenerTodosContactosAgenda()
        {
            return _context.AgendaContactos.ToList();
        }

        // Obtener un contacto de la agenda por ID
        public AgendaContacto ObtenerContactoAgendaPorId(string id)
        {
            try
            {
                return _context.AgendaContactos.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el contacto de la agenda por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo contacto a la agenda
        public void AgregarContactoAgenda(AgendaContacto nuevoContactoAgenda)
        {
            try
            {
                _context.AgendaContactos.Add(nuevoContactoAgenda);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el contacto a la agenda: {ex.Message}");
            }
        }

        // Eliminar un contacto de la agenda por ID
        public void EliminarContactoAgenda(string id)
        {
            try
            {
                var contactoAEliminar = _context.AgendaContactos.Find(id);

                if (contactoAEliminar != null)
                {
                    _context.AgendaContactos.Remove(contactoAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el contacto de la agenda: {ex.Message}");
            }
        }

        // Editar un contacto de la agenda por ID
        public void EditarContactoAgenda(string id, AgendaContacto contactoAgendaEditado)
        {
            try
            {
                if (id != contactoAgendaEditado.Id)
                {
                    throw new InvalidOperationException("ID del contacto de la agenda no coincide");
                }

                _context.Entry(contactoAgendaEditado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el contacto de la agenda: {ex.Message}");
            }
        }
    }
}
