using Microsoft.AspNetCore.Authorization;
using senai_SPmedicals_webapi.Context;
using senai_SPmedicals_webapi.Domains;
using senai_SPmedicals_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        SpmedicalsContext ctx = new SpmedicalsContext();

        [Authorize(Roles = "3")]
        public Medico BuscarporId(int IdMedico)
        {
            return ctx.Medicos
                .Select(u => new Medico()
                {
                    IdMedico = u.IdMedico,
                    IdClinica = u.IdClinica,
                    IdEspecialidade = u.IdEspecialidade,
                    IdUsuario = u.IdUsuario,
                    Consulta = u.Consulta
                })
                .FirstOrDefault(u => u.IdMedico == IdMedico);
        }

        public List<Medico> Lista()
        {
            return ctx.Medicos.ToList();
        }
    }
}
