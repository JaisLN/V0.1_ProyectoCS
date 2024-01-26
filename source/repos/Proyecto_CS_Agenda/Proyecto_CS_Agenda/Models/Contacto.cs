using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            ContactoAgenda = new HashSet<ContactoAgendum>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? NombreContact { get; set; }
        public string? Mail { get; set; }
        public string Telf1 { get; set; } = null!;
        public string? Telf2 { get; set; }
        public string? Direccion { get; set; }
        public int RolId { get; set; }

        public virtual RolContacto Rol { get; set; } = null!;
        public virtual ICollection<ContactoAgendum> ContactoAgenda { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
