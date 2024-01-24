﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Controllers
{
    public class RolSistemaController
    {
        private readonly p1ConstSoftContext _context;

        public RolSistemaController(p1ConstSoftContext context)
        {
            _context = context;
        }

        // Obtener todos los roles del sistema
        public List<RolSistema> ObtenerTodosRoles()
        {
            return _context.RolSistemas.ToList();
        }

        // Obtener un rol del sistema por ID
        public RolSistema ObtenerRolPorId(string id)
        {
            try
            {
                return _context.RolSistemas.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el rol por ID: {ex.Message}");
                return null;
            }
        }

        // Agregar un nuevo rol del sistema
        public void AgregarRol(RolSistema nuevoRol)
        {
            try
            {
                _context.RolSistemas.Add(nuevoRol);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el rol: {ex.Message}");
            }
        }

        // Eliminar un rol del sistema por ID
        public void EliminarRol(string id)
        {
            try
            {
                var rolAEliminar = _context.RolSistemas.Find(id);

                if (rolAEliminar != null)
                {
                    _context.RolSistemas.Remove(rolAEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol: {ex.Message}");
            }
        }

        // Editar un rol del sistema por ID
        public void EditarRol(string id, RolSistema rolEditado)
        {
            try
            {
                if (id != rolEditado.Id)
                {
                    throw new InvalidOperationException("ID del rol no coincide");
                }

                _context.Entry(rolEditado).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el rol: {ex.Message}");
            }
        }
    }
}
