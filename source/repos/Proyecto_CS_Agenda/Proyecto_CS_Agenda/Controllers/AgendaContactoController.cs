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

        
        //Vincular Contactos globales a una Agenda
        public void VincularContactosAAgenda(int agendaId, List<Contacto> contactos)
        {
            try
            {
                // Verificar que la agenda exista
                var agenda = _context.Agenda.Find(agendaId);
                if (agenda == null)
                {
                    Console.WriteLine("La agenda no existe.");
                    return;
                }

                // Obtener los IDs de los contactos vinculados a la agenda
                var contactosVinculadosIds = _context.ContactoAgenda
                    .Where(ac => ac.AgendaId == agendaId)
                    .Select(ac => ac.ContactoId)
                    .ToList();

                // Filtrar los contactos para evitar duplicados
                var contactosNoDuplicados = contactos.Where(c => !contactosVinculadosIds.Contains(c.Id)).ToList();

                // Vincular los contactos a la agenda
                foreach (var contacto in contactosNoDuplicados)
                {
                    _context.ContactoAgenda.Add(new ContactoAgendum
                    {
                        AgendaId = agendaId,
                        ContactoId = contacto.Id
                    });
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al vincular contactos a la agenda: {ex.Message}");
            }
        }



        //Obtener todos los registros que corresponden al campo AgendaID
        public List<ContactoAgendum> ObtenerContactosPorAgendaId(int agendaId)
        {
            try
            {
                // Filtrar los registros de ContactoAgendum por el AgendaId
                var contactosAgenda = _context.ContactoAgenda
                    .Where(ac => ac.AgendaId == agendaId)
                    .ToList();

                return contactosAgenda;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener contactos por AgendaId: {ex.Message}");
                return new List<ContactoAgendum>();
            }
        }


        //eliminar por Agenda ID los registros de los contactos vinculados a esa Agenda
        public void EliminarContactoAgendumPorAgendaId(int agendaId)
        {
            try
            {
                // Obtener los registros de ContactoAgendum que coinciden con el AgendaId
                var contactosAgendumAEliminar = _context.ContactoAgenda
                    .Where(ca => ca.AgendaId == agendaId)
                    .ToList();

                // Eliminar los registros de ContactoAgendum
                _context.ContactoAgenda.RemoveRange(contactosAgendumAEliminar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar registros de ContactoAgendum por AgendaId: {ex.Message}");
            }
        }

        //eliminar por Agenda ID los registros de los contactos vinculados a esa Agenda
        public void EliminarContactoAgendumPorContactoID(int ctoId)
        {
            try
            {
                // Obtener los registros de ContactoAgendum que coinciden con el AgendaId
                var contactosAgendumAEliminar = _context.ContactoAgenda
                    .Where(ca => ca.ContactoId == ctoId)
                    .ToList();

                // Eliminar los registros de ContactoAgendum
                _context.ContactoAgenda.RemoveRange(contactosAgendumAEliminar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar registros de ContactoAgendum por AgendaId: {ex.Message}");
            }
        }

    }
}
