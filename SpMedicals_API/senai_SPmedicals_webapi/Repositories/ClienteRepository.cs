using senai_SPmedicals_webapi.Domains;
using senai_SPmedicals_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente buscarporId(int IdPaciente)
        {
                return ctx.Cliente
                    .Select(u => new Consultum()
                    {
                        IdConsulta = u.IdConsulta,
                        IdMedico = u.IdMedico,
                        IdClientes = u.IdClientes,
                        DataConsulta = u.DataConsulta,
                        DescConsulta = u.DescConsulta,
                        IdSituacao = u.IdSituacao
                    })
                    .FirstOrDefault(u => u.IdConsulta == IdConsulta);
        }
    }
}
