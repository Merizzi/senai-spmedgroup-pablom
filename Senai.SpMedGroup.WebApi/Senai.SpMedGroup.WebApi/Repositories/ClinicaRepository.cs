using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            clinicaBuscada.Idclinica = clinicaAtualizada.Idclinica;

            ctx.Clinica.Update(clinicaBuscada);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinica.FirstOrDefault(c => c.Idclinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);
            ctx.Clinica.Remove(clinicaBuscada);
            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinica.ToList();
        }
    }
}
