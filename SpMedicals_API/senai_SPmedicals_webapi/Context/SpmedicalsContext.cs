using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_SPmedicals_webapi.Domains;

#nullable disable

namespace senai_SPmedicals_webapi.Context
{
    public partial class SpmedicalsContext : DbContext
    {
        public SpmedicalsContext()
        {
        }

        public SpmedicalsContext(DbContextOptions<SpmedicalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE0113E4\\SQLEXPRESS; initial catalog=SPmedicals; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__Administ__4A3006F74C5756A3");

                entity.ToTable("Administrador");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Admin_Id");

                entity.Property(e => e.NomeAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Admin");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Administr__Usuar__3B75D760");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdClientes)
                    .HasName("PK__Clientes__731F3B2EC63DAFF4");

                entity.Property(e => e.IdClientes)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Clientes");

                entity.Property(e => e.CpfPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPF_Paciente");

                entity.Property(e => e.DataNasc)
                    .HasColumnType("date")
                    .HasColumnName("data_Nasc");

                entity.Property(e => e.EndPaciente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("End_Paciente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Cliente");

                entity.Property(e => e.RgPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_Paciente");

                entity.Property(e => e.TelPaciente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tel_Paciente");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Clientes__Usuari__3E52440B");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__FCCE236D53A23E83");

                entity.ToTable("Clinica");

                entity.Property(e => e.IdClinica)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Clinica");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.EnderecoClinica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Endereco_Clinica");

                entity.Property(e => e.HorarioAbrir).HasColumnName("Horario_abrir");

                entity.Property(e => e.HorarioFechar).HasColumnName("Horario_fechar");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Razao_Social");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__Clinica__Admin_I__412EB0B6");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__C6582588861E7A56");

                entity.Property(e => e.IdConsulta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Consulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("Data_Consulta");

                entity.Property(e => e.DescConsulta)
                    .HasColumnType("text")
                    .HasColumnName("desc_Consulta");

                entity.Property(e => e.IdClientes).HasColumnName("Id_Clientes");

                entity.Property(e => e.IdMedico).HasColumnName("Id_Medico");

                entity.Property(e => e.IdSituacao).HasColumnName("Id_Situacao");

                entity.HasOne(d => d.IdClientesNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdClientes)
                    .HasConstraintName("FK__Consulta__Id_Cli__4D94879B");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__Id_Med__4CA06362");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__Id_Sit__4E88ABD4");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__C4CBC02B9C8BFB2F");

                entity.ToTable("Especialidade");

                entity.Property(e => e.IdEspecialidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Especialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Especialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__7BA5D8108BE2A065");

                entity.Property(e => e.IdMedico)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Medico");

                entity.Property(e => e.CrmMedico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRM_Medico");

                entity.Property(e => e.IdClinica).HasColumnName("Id_Clinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("Id_Especialidade");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.NomeMedico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Medico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medicos__Id_Clin__45F365D3");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medicos__Id_Espe__46E78A0C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medicos__Id_Usua__47DBAE45");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__7DFBB1BAA5791416");

                entity.ToTable("Situacao");

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Situacao");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.TipoUserId)
                    .HasName("PK__TipoUsua__F5DF7227F989A8EF");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.TipoUserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TipoUser_Id");

                entity.Property(e => e.TipoNome)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Nome");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Usuario_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUserId).HasColumnName("TipoUser_Id");

                entity.HasOne(d => d.TipoUser)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUserId)
                    .HasConstraintName("FK__Usuario__TipoUse__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
