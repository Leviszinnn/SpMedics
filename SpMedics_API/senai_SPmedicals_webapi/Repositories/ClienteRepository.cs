using senai_SPmedicals_webapi.Context;
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
        SpmedicalsContext ctx = new SpmedicalsContext();
        public Cliente buscarporId(int IdPaciente)
        {
                return ctx.Clientes
                    .Select(u => new Cliente()
                    {
                        IdClientes = u.IdClientes,
                        UsuarioId = u.UsuarioId,
                        NomeCliente = u.NomeCliente,
                        DataNasc = u.DataNasc,
                        TelPaciente = u.TelPaciente,
                        RgPaciente = u.RgPaciente,
                        CpfPaciente = u.CpfPaciente,
                        EndPaciente = u.EndPaciente,
                        Consulta = u.Consulta
                    })
                    .FirstOrDefault(u => u.IdClientes == IdPaciente);
        }

        public Cliente buscarUsuarioLog(int IdUsuario)
        {
            return ctx.Clientes
                .Select(u => new Cliente()
                {
                    IdClientes = u.IdClientes,
                    UsuarioId = u.UsuarioId,
                    NomeCliente = u.NomeCliente,
                    DataNasc = u.DataNasc,
                    TelPaciente = u.TelPaciente,
                    RgPaciente = u.RgPaciente,
                    CpfPaciente = u.CpfPaciente,
                    EndPaciente = u.EndPaciente,
                    Consulta = u.Consulta
                })
                .FirstOrDefault(u => u.UsuarioId == IdUsuario);
        }
    }
}
