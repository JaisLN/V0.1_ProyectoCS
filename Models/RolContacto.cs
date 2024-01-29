using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class RolContacto
    {
        public RolContacto()
        {
            Contactos = new HashSet<Contacto>();
        }

        public string Id { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
