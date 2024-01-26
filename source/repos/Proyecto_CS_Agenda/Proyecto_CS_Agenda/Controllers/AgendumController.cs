using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AgendumController
    {
        private readonly ConstSoft_agendaContext _context;

        public AgendumController(ConstSoft_agendaContext context)
        {
            _context = context;
        }

        /// Obtener todas las agendas
        public List<Agendum> ObtenerTodasAgendas()
        {
            return _context.Agenda.ToList();
        }

        // Obtener una agenda por ID
        public Agendum ObtenerAgendaPorId(int id)
        {
            try
            {
                return _context.Agenda.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la agenda por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar una nueva agenda
        public void AgregarAgenda(Agendum nuevaAgenda)
        {
            try
            {
                _context.Agenda.Add(nuevaAgenda);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la agenda: {ex.Message}");
            }
        }

        // Eliminar una agenda por ID
        public void EliminarAgenda(int id)
        {
            try
            {
                var agendaAEliminar = _context.Agenda.Find(id);

                if (agendaAEliminar != null)
                {
                    _context.Agenda.Remove(agendaAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la agenda: {ex.Message}");
            }
        }

        // Editar una agenda por ID
        public void EditarAgenda(int id, Agendum agendaEditada)
        {
            try
            {
                if (id != agendaEditada.Id)
                {
                    throw new InvalidOperationException("ID de la agenda no coincide");
                }

                _context.Entry(agendaEditada).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar la agenda: {ex.Message}");
            }
        }
    }
}
