using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class SpMedContext : DbContext
    {
        public SpMedContext()
        {
        }

        public SpMedContext(DbContextOptions<SpMedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Prontuario> Prontuario { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source=DEV1401\\SQLEXPRESS; initial Catalog=Clinicaprojeto_manha; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Idclinica);

                entity.Property(e => e.Idclinica).HasColumnName("IDClinica");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioFuncionamento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.Idconsulta);

                entity.Property(e => e.Idconsulta).HasColumnName("IDConsulta");

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__IdMedi__5BE2A6F2");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .HasConstraintName("FK__Consulta__IdPron__5DCAEF64");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__IdSitu__5CD6CB2B");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.Idespecialidade);

                entity.Property(e => e.Idespecialidade).HasColumnName("IDEspecialidade");

                entity.Property(e => e.Especialidade1)
                    .HasColumnName("Especialidade")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.Idmedico);

                entity.Property(e => e.Idmedico).HasColumnName("IDMedico");

                entity.Property(e => e.Crm)
                    .HasColumnName("CRM")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__IdClinic__571DF1D5");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__IdEspeci__59063A47");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__IdUsuari__5812160E");
            });

            modelBuilder.Entity<Prontuario>(entity =>
            {
                entity.HasKey(e => e.Idprontuario);

                entity.Property(e => e.Idprontuario).HasColumnName("IDProntuario");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.NomePaciente)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Prontuari__IdUsu__52593CB8");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.Idsituacao);

                entity.Property(e => e.Idsituacao).HasColumnName("IDSituacao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUsuario);

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__4F7CD00D");
            });
        }
    }
}
