using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        void Cadastrar(Consulta cadastrarConsulta);

        Consulta BuscarPorId(int id);

        void Atualizar(int id, Consulta consultaAtualizada);

        void Deletar(int id);
    }
}
