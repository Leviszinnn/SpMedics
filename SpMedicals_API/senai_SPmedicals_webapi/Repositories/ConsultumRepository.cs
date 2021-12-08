using Microsoft.EntityFrameworkCore;
using senai_SPmedicals_webapi.Context;
using senai_SPmedicals_webapi.Domains;
using senai_SPmedicals_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Repositories
{
    public class ConsultumRepository : IConsultumRepository
    {
        SpmedicalsContext ctx = new SpmedicalsContext();

        public void Atualizar(int id, Consultum ConsultaAtt)
        {
            Consultum ConsultaBuscada = ctx.Consulta.Find(id);

            if (ConsultaAtt.IdMedico != null)
            {
                ConsultaBuscada.IdMedico = ConsultaAtt.IdMedico;
            }

            if (ConsultaAtt.IdClientes != null)
            {
                ConsultaBuscada.IdClientes = ConsultaAtt.IdClientes;
            }

            if (ConsultaAtt.IdSituacao != null)
            {
                ConsultaBuscada.IdSituacao = ConsultaAtt.IdSituacao;
            }

            if (ConsultaAtt.DescConsulta != null)
            {
                ConsultaBuscada.DescConsulta = ConsultaAtt.DescConsulta;
            }

            if (ConsultaAtt.DataConsulta != null)
            {
                ConsultaBuscada.DataConsulta = ConsultaAtt.DataConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);
            ctx.SaveChanges();
        }

        public Consultum buscarporId(int IdConsulta)
        {
            return ctx.Consulta
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
        public void Cadastrar(Consultum cadastrar)
        {
            ctx.Consulta.Add(cadastrar);
            ctx.SaveChanges();
        }
        public void Deletar(int IdConsulta)
        {
            Consultum consultaBuscada = buscarporId(IdConsulta);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();

        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta.ToList();
        }
    }
}