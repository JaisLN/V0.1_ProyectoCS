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

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
