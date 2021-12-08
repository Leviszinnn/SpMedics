using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public byte IdClientes { get; set; }
        public byte? UsuarioId { get; set; }
        public string NomeCliente { get; set; }
        public DateTime? DataNasc { get; set; }
        public string TelPaciente { get; set; }
        public string RgPaciente { get; set; }
        public string CpfPaciente { get; set; }
        public string EndPaciente { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
