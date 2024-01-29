using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class Agendum
    {
        public Agendum()
        {
            AgendaContactos = new HashSet<AgendaContacto>();
        }

        public string Id { get; set; } = null!;
        public string? UserId { get; set; }

        public virtual Usuario? User { get; set; }
        public virtual ICollection<AgendaContacto> AgendaContactos { get; set; }
    }
}
