using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public byte IdMedico { get; set; }
        public byte? IdClinica { get; set; }
        public byte? IdEspecialidade { get; set; }
        public byte? IdUsuario { get; set; }
        public string CrmMedico { get; set; }
        public string NomeMedico { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
