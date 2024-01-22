using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class AgendaContacto
    {
        public string Id { get; set; } = null!;
        public string AgendaId { get; set; } = null!;
        public string ContactoId { get; set; } = null!;

        public virtual Agendum Agenda { get; set; } = null!;
        public virtual Contacto Contacto { get; set; } = null!;
    }
}
