using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte TipoUserId { get; set; }
        public string TipoNome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
