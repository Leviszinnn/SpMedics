using senai_SPmedicals_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Lista();

        Medico BuscarporId(int IdMedico);


    }
}
