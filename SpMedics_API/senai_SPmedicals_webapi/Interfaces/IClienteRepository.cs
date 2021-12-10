using senai_SPmedicals_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Interfaces
{
    interface IClienteRepository
    {
        Cliente buscarporId(int IdPaciente);

        Cliente buscarUsuarioLog(int IdUsuario);
    }
}
