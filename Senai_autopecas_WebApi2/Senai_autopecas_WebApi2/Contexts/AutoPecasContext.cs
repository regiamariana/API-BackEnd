using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai_autopecas_WebApi2.Domains
{
    public partial class AutoPecasContext : DbContext
    {
        public AutoPecasContext()
        {
        }

        public AutoPecasContext(DbContextOptions<AutoPecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_AutoPecas;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.Idfornecedor);

                entity.ToTable("FORNECEDORES");

                entity.HasIndex(e => e.Nomefantasia)
                    .HasName("UQ__FORNECED__F8B2DA847ACF4D65")
                    .IsUnique();

                entity.HasIndex(e => e.Razaosocial)
                    .HasName("UQ__FORNECED__82947A57DF317E92")
                    .IsUnique();

                entity.Property(e => e.Idfornecedor).HasColumnName("IDFORNECEDOR");

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Nomefantasia)
                    .IsRequired()
                    .HasColumnName("NOMEFANTASIA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Razaosocial)
                    .IsRequired()
                    .HasColumnName("RAZAOSOCIAL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__FORNECEDO__IDUSU__4E88ABD4");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.Idpeca);

                entity.ToTable("PECAS");

                entity.HasIndex(e => e.Codigopeca)
                    .HasName("UQ__PECAS__826607D9E73B8EC6")
                    .IsUnique();

                entity.Property(e => e.Idpeca).HasColumnName("IDPECA");

                entity.Property(e => e.Codigopeca)
                    .IsRequired()
                    .HasColumnName("CODIGOPECA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idfornecedor).HasColumnName("IDFORNECEDOR");

                entity.Property(e => e.Peso).HasColumnName("PESO");

                entity.Property(e => e.Precocusto).HasColumnName("PRECOCUSTO");

                entity.Property(e => e.Precovenda).HasColumnName("PRECOVENDA");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("FK__PECAS__IDFORNECE__52593CB8");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724AE73AC5A")
                    .IsUnique();

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .HasColumnName("PERMISSAO")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('COMUM')");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
