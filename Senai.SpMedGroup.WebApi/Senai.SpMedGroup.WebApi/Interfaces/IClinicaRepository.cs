using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int id, Clinica clinicaAtualizada);

        void Deletar(int id);

        Clinica BuscarPorId(int id);
    }
}
