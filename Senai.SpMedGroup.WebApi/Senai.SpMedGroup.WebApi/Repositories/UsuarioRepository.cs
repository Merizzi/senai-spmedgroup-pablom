using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            ctx.Usuario.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Idusuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);
            ctx.Usuario.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
