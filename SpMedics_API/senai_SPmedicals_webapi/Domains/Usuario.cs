using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPmedicals_webapi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administradors = new HashSet<Administrador>();
            Clientes = new HashSet<Cliente>();
            Medicos = new HashSet<Medico>();
        }

        public byte UsuarioId { get; set; }
        public byte? TipoUserId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario TipoUser { get; set; }
        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
