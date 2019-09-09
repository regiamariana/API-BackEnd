using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Classificacao> Classificacao { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Tipousuario> Tipousuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.PLATAFORMALANCAMENTO'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_OPFLIX;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria);

                entity.ToTable("CATEGORIA");

                entity.HasIndex(e => e.Categoria1)
                    .HasName("UQ__CATEGORI__DC9274C72D95F7F4")
                    .IsUnique();

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Categoria1)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.HasKey(e => e.Idclassificacao);

                entity.ToTable("CLASSIFICACAO");

                entity.Property(e => e.Idclassificacao).HasColumnName("IDCLASSIFICACAO");

                entity.Property(e => e.Classificacao1)
                    .IsRequired()
                    .HasColumnName("CLASSIFICACAO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.Idlancamentos);

                entity.ToTable("LANCAMENTOS");

                entity.Property(e => e.Idlancamentos).HasColumnName("IDLANCAMENTOS");

                entity.Property(e => e.Datalancamento)
                    .HasColumnName("DATALANCAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Idclassificaca).HasColumnName("IDCLASSIFICACA");

                entity.Property(e => e.Idclassificacao).HasColumnName("IDCLASSIFICACAO");

                entity.Property(e => e.Idplataforma).HasColumnName("IDPLATAFORMA");

                entity.Property(e => e.Idtipo).HasColumnName("IDTIPO");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnName("SINOPSE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tempoduracao).HasColumnName("TEMPODURACAO");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK__LANCAMENT__IDCAT__59FA5E80");

                entity.HasOne(d => d.IdclassificacaoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Idclassificacao)
                    .HasConstraintName("FK__LANCAMENT__IDCLA__73BA3083");

                entity.HasOne(d => d.IdplataformaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Idplataforma)
                    .HasConstraintName("FK__LANCAMENT__IDPLA__5BE2A6F2");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Idtipo)
                    .HasConstraintName("FK__LANCAMENT__IDTIP__5AEE82B9");
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.HasKey(e => e.Idplataforma);

                entity.ToTable("PLATAFORMA");

                entity.HasIndex(e => e.Plataforma1)
                    .HasName("UQ__PLATAFOR__B9B1299E5C0EDE24")
                    .IsUnique();

                entity.Property(e => e.Idplataforma).HasColumnName("IDPLATAFORMA");

                entity.Property(e => e.Plataforma1)
                    .IsRequired()
                    .HasColumnName("PLATAFORMA")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.Idtipo);

                entity.ToTable("TIPO");

                entity.HasIndex(e => e.Tipo1)
                    .HasName("UQ__TIPO__B6FCAAA236284A70")
                    .IsUnique();

                entity.Property(e => e.Idtipo).HasColumnName("IDTIPO");

                entity.Property(e => e.Tipo1)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.Idtipousuario);

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.Tipousuario1)
                    .HasName("UQ__TIPOUSUA__F21423EA4573351F")
                    .IsUnique();

                entity.Property(e => e.Idtipousuario).HasColumnName("IDTIPOUSUARIO");

                entity.Property(e => e.Tipousuario1)
                    .IsRequired()
                    .HasColumnName("TIPOUSUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIO__161CF724C6A0E877")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__USUARIO__C8727D6576BFD9C5")
                    .IsUnique();

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idtipousuario).HasColumnName("IDTIPOUSUARIO");

                entity.Property(e => e.Imagem)
                    .HasColumnName("IMAGEM")
                    .HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnName("TELEFONE");

                entity.HasOne(d => d.IdtipousuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idtipousuario)
                    .HasConstraintName("FK__USUARIO__IDTIPOU__5441852A");
            });
        }
    }
}
