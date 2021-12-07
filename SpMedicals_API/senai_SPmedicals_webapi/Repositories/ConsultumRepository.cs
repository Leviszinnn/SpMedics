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

        public Consultum buscarporId(int IdConsulta)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdConsulta == IdConsulta);
        }

        public void Cadastrar(Consultum cadastrar)
        {
            ctx.Consulta.Add(cadastrar);
            ctx.SaveChanges();
        }

        public void Deletar(int IdConsulta)
        {   
            Consultum consultaBuscada = buscarporId(IdConsulta);

            ctx.Consulta.Remove(buscarporId(IdConsulta));

            ctx.SaveChanges();

        }

        public List<Consultum> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários, exceto as senhas



            return ctx.Consulta.ToList();

            //return ctx.Consulta
                //.Select(u => new Consultum()
                //{
                //    IdMedicoNavigation = new Medico()
                //    {
                //        NomeMedico = u.IdMedicoNavigation.NomeMedico,
                //        CrmMedico = u.IdMedicoNavigation.CrmMedico
                //    },
                //    DataConsulta = u.DataConsulta,
                //    DescConsulta = u.DescConsulta,
                //})
                //.ToList();
        }

        //public List<Consultum> ListConsultas()
        //{
        //    return ctx.Consultum

        //        .Select(c => new Consultum()
        //        {
        //            IdConsulta = c.IdConsulta,
        //            IdMedico = c.IdMedico,
        //            IdClientes = c.IdClientes,
        //            DataConsulta = c.DataConsulta,
        //            DescConsulta = c.DescConsulta,

        //            IdMedicoNavigation = new Medico()
        //            {
        //                CrmMedico = c.IdMedicoNavigation.CrmMedico
        //            }
        //        })
        //        .ToList();
        //}
    }
}
