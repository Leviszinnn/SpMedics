using Microsoft.AspNetCore.Http;
using senai_SPmedicals_webapi.Context;
using senai_SPmedicals_webapi.Domains;
using senai_SPmedicals_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpmedicalsContext ctx = new SpmedicalsContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
