using System;
using System.Collections.Generic;

namespace Proyecto_CS_Agenda.Models
{
    public partial class Agendum
    {
        public Agendum()
        {
            ContactoAgenda = new HashSet<ContactoAgendum>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual Usuario User { get; set; } = null!;
        public virtual ICollection<ContactoAgendum> ContactoAgenda { get; set; }
    }
}
