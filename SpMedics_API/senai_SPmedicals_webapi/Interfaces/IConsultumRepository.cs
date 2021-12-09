using senai_SPmedicals_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Interfaces
{
    interface IConsultumRepository
    {
        List<Consultum> Listar();

        void Cadastrar(Consultum cadastrar);

        void Deletar(int IdConsulta);

        Consultum buscarporId(int IdConsulta);

        void Atualizar(int id, Consultum ConsultaAtt);
    }
}
