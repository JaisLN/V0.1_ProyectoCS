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

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int SystemRol { get; set; }
        public int? ContactId { get; set; }

        public virtual Contacto? Contact { get; set; }
        public virtual RolSistema SystemRolNavigation { get; set; } = null!;
        public virtual ICollection<Agendum> Agenda { get; set; }
    }
}


