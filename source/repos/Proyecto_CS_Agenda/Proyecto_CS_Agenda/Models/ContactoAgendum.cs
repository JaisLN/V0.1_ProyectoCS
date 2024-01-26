using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class ContactoAgendum
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public int ContactoId { get; set; }

        public virtual Agendum Agenda { get; set; } = null!;
        public virtual Contacto Contacto { get; set; } = null!;
    }
}
