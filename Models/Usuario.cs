using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Agenda = new HashSet<Agendum>();
        }

        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string SystemRolId { get; set; } = null!;
        public string ContactId { get; set; } = null!;

        public virtual Contacto Contact { get; set; } = null!;
        public virtual RolSistema SystemRol { get; set; } = null!;
        public virtual ICollection<Agendum> Agenda { get; set; }
    }
}
