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
        private readonly ConstSoft_agendaContext _context;

        public AgendaContactoController(ConstSoft_agendaContext context)
        {
            _context = context;
        }

        // Obtener todos los contactos de la agenda
        public List<ContactoAgendum> ObtenerTodosContactosAgenda()
        {
            return _context.ContactoAgenda.ToList();
        }

        // Obtener un contacto de la agenda por ID
        public ContactoAgendum ObtenerContactoAgendaPorId(int id)
        {
            try
            {
                return _context.ContactoAgenda.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el contacto de la agenda por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo contacto a la agenda
        public void AgregarContactoAgenda(ContactoAgendum nuevoContactoAgenda)
        {
            try
            {
                _context.ContactoAgenda.Add(nuevoContactoAgenda);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el contacto a la agenda: {ex.Message}");
            }
        }

        // Eliminar un contacto de la agenda por ID
        public void EliminarContactoAgenda(int id)
        {
            try
            {
                var contactoAEliminar = _context.ContactoAgenda.Find(id);

                if (contactoAEliminar != null)
                {
                    _context.ContactoAgenda.Remove(contactoAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el contacto de la agenda: {ex.Message}");
            }
        }

        // Editar un contacto de la agenda por ID
        public void EditarContactoAgenda(int id, ContactoAgendum contactoAgendaEditado)
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
