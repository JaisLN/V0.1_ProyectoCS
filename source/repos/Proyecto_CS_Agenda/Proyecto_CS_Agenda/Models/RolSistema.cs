using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class RolSistema
    {
        public RolSistema()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
