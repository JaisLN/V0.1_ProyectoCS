using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            AgendaContactos = new HashSet<AgendaContacto>();
            Usuarios = new HashSet<Usuario>();
        }

        public string Id { get; set; } = null!;
        public string NombreContact { get; set; } = null!;
        public string? Mail { get; set; }
        public string? Telf1 { get; set; }
        public string? Telf2 { get; set; }
        public string? Direccion { get; set; }
        public string RolId { get; set; } = null!;

        public virtual RolContacto Rol { get; set; } = null!;
        public virtual ICollection<AgendaContacto> AgendaContactos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
