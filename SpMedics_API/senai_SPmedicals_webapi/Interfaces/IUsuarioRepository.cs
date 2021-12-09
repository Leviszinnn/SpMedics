using Microsoft.AspNetCore.Http;
using senai_SPmedicals_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario cadastrar);
    }
}