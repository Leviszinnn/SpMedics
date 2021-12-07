using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdClinica { get; set; }
        public byte? AdminId { get; set; }
        public string EnderecoClinica { get; set; }
        public string RazaoSocial { get; set; }
        public string HorarioAbrir { get; set; }
        public string HorarioFechar { get; set; }

        public virtual Administrador Admin { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
