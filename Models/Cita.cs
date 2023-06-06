using System;
using System.Collections.Generic;

namespace demo.Models
{
    public partial class Cita
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fechacita { get; set; }
        public long? DestinatariosId { get; set; }

        public virtual Destinatario? Destinatarios { get; set; }
    }
}
