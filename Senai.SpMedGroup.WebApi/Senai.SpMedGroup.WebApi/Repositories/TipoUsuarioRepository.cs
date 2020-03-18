using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(t => t.IdtipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
