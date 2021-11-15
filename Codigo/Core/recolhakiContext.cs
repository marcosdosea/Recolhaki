using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class recolhakiContext : DbContext
    {
        public recolhakiContext()
        {
        }

        public recolhakiContext(DbContextOptions<recolhakiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autorizacaocoletor> Autorizacaocoletor { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Coletor> Coletor { get; set; }
        public virtual DbSet<Doacaomaterialreciclavel> Doacaomaterialreciclavel { get; set; }
        public virtual DbSet<Notificacao> Notificacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=recolhaki");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorizacaocoletor>(entity =>
            {
                entity.HasKey(e => new { e.ColetorIdColetor, e.PessoaIdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("autorizacaocoletor");

                entity.HasIndex(e => e.ColetorIdColetor)
                    .HasName("fk_Coletor_has_Pessoa_Coletor1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_Coletor_has_Pessoa_Pessoa1_idx");

                entity.Property(e => e.ColetorIdColetor).HasColumnName("Coletor_idColetor");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("Pessoa_idPessoa");

                entity.Property(e => e.DataAutorizacao).HasColumnName("dataAutorizacao");

                entity.Property(e => e.StatusAutorizacao)
                    .IsRequired()
                    .HasColumnName("statusAutorizacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.ColetorIdColetorNavigation)
                    .WithMany(p => p.Autorizacaocoletor)
                    .HasForeignKey(d => d.ColetorIdColetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Coletor_has_Pessoa_Coletor1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Autorizacaocoletor)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Coletor_has_Pessoa_Pessoa1");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PRIMARY");

                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.DoacaoMaterialReciclavelIdDoacaoMaterialReciclavel)
                    .HasName("fk_Avaliacao_DoacaoMaterialReciclavel1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_Avaliacao_Pessoa1_idx");

                entity.Property(e => e.IdAvaliacao).HasColumnName("idAvaliacao");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.DoacaoMaterialReciclavelIdDoacaoMaterialReciclavel).HasColumnName("DoacaoMaterialReciclavel_idDoacaoMaterialReciclavel");

                entity.Property(e => e.IdEmoje).HasColumnName("id_emoje");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("Pessoa_idPessoa");

                entity.HasOne(d => d.DoacaoMaterialReciclavelIdDoacaoMaterialReciclavelNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.DoacaoMaterialReciclavelIdDoacaoMaterialReciclavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_DoacaoMaterialReciclavel1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_Pessoa1");
            });

            modelBuilder.Entity<Coletor>(entity =>
            {
                entity.HasKey(e => e.IdColetor)
                    .HasName("PRIMARY");

                entity.ToTable("coletor");

                entity.Property(e => e.IdColetor).HasColumnName("idColetor");

                entity.Property(e => e.Coletorcol)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doacaomaterialreciclavel>(entity =>
            {
                entity.HasKey(e => e.IdDoacaoMaterialReciclavel)
                    .HasName("PRIMARY");

                entity.ToTable("doacaomaterialreciclavel");

                entity.HasIndex(e => e.ColetorIdColetor)
                    .HasName("fk_DoacaoMaterialReciclavel_Coletor1_idx");

                entity.HasIndex(e => e.NotificacaoIdNotificacao)
                    .HasName("fk_DoacaoMaterialReciclavel_Notificacao1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_DoacaoMaterialReciclavel_Pessoa1_idx");

                entity.Property(e => e.IdDoacaoMaterialReciclavel).HasColumnName("idDoacaoMaterialReciclavel");

                entity.Property(e => e.ColetorIdColetor).HasColumnName("Coletor_idColetor");

                entity.Property(e => e.DataManifestacaoInteresse).HasColumnName("dataManifestacaoInteresse");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotificacaoIdNotificacao).HasColumnName("Notificacao_idNotificacao");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("Pessoa_idPessoa");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.ColetorIdColetorNavigation)
                    .WithMany(p => p.Doacaomaterialreciclavel)
                    .HasForeignKey(d => d.ColetorIdColetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DoacaoMaterialReciclavel_Coletor1");

                entity.HasOne(d => d.NotificacaoIdNotificacaoNavigation)
                    .WithMany(p => p.Doacaomaterialreciclavel)
                    .HasForeignKey(d => d.NotificacaoIdNotificacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DoacaoMaterialReciclavel_Notificacao1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Doacaomaterialreciclavel)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DoacaoMaterialReciclavel_Pessoa1");
            });

            modelBuilder.Entity<Notificacao>(entity =>
            {
                entity.HasKey(e => e.IdNotificacao)
                    .HasName("PRIMARY");

                entity.ToTable("notificacao");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Notificacao_Pessoa1_idx");

                entity.Property(e => e.IdNotificacao).HasColumnName("idNotificacao");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Notificacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Notificacao_Pessoa1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
