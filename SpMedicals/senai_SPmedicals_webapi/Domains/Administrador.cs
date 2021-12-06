using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class Administrador
    {
        public Administrador()
        {
            Clinicas = new HashSet<Clinica>();
        }

        public byte AdminId { get; set; }
        public byte? UsuarioId { get; set; }
        public string NomeAdmin { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Clinica> Clinicas { get; set; }
    }
}
