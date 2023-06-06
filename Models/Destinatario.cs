using System;
using System.Collections.Generic;

namespace demo.Models
{
    public partial class Destinatario
    {
        public Destinatario()
        {
            Cita = new HashSet<Cita>();
        }

        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public long? Telefono { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
