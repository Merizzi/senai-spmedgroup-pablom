using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.Idconsulta == id);
        }

        public void Cadastrar(Consulta cadastrarConsulta)
        {
            ctx.Add(cadastrarConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(consultaBuscada);
            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta.ToList();
        }
    }
}
