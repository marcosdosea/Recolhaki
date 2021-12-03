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

        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Empresacoletor> Empresacoletor { get; set; }
        public virtual DbSet<Materialreciclavel> Materialreciclavel { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
           //     optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=recolhakii");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PRIMARY");

                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.IdMaterialReciclavel)
                    .HasName("fk_Avaliacao_MaterialReciclavel1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Avaliacao_Pessoa1_idx");

                entity.Property(e => e.IdAvaliacao).HasColumnName("idAvaliacao");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdMaterialReciclavel).HasColumnName("idMaterialReciclavel");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.NumeroEstrelas).HasColumnName("numeroEstrelas");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('COMENTARIO','PROBLEMA')")
                    .HasDefaultValueSql("'COMENTARIO'");

                entity.HasOne(d => d.IdMaterialReciclavelNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdMaterialReciclavel)
                    .HasConstraintName("fk_Avaliacao_MaterialReciclavel1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("fk_Avaliacao_Pessoa1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("cnpj_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

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

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasMaxLength(100)
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
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresacoletor>(entity =>
            {
                entity.HasKey(e => new { e.IdEmpresa, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("empresacoletor");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_EmpresaPessoa_Empresa1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_EmpresaPessoa_Pessoa1_idx");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.DataAutorizacao).HasColumnName("dataAutorizacao");

                entity.Property(e => e.PrazoColetaHoras)
                    .HasColumnName("prazoColetaHoras")
                    .HasDefaultValueSql("'48'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('ATIVO','INATIVO')")
                    .HasDefaultValueSql("'INATIVO'");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Empresacoletor)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fk_EmpresaPessoa_Empresa1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Empresacoletor)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("fk_EmpresaPessoa_Pessoa1");
            });

            modelBuilder.Entity<Materialreciclavel>(entity =>
            {
                entity.HasKey(e => e.IdMaterialReciclavel)
                    .HasName("PRIMARY");

                entity.ToTable("materialreciclavel");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_MaterialReciclavel_Empresa1_idx");

                entity.HasIndex(e => e.IdPessoaColetor)
                    .HasName("fk_MaterialReciclavel_Pessoa1_idx");

                entity.HasIndex(e => e.IdPessoaDoador)
                    .HasName("fk_MaterialReciclavel_Pessoa2_idx");

                entity.Property(e => e.IdMaterialReciclavel).HasColumnName("idMaterialReciclavel");

                entity.Property(e => e.DataColeta).HasColumnName("dataColeta");

                entity.Property(e => e.DataManifestacaoInteresse).HasColumnName("dataManifestacaoInteresse");

                entity.Property(e => e.DataNotificacao).HasColumnName("dataNotificacao");

                entity.Property(e => e.DataSolicitacao).HasColumnName("dataSolicitacao");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdPessoaColetor).HasColumnName("idPessoaColetor");

                entity.Property(e => e.IdPessoaDoador).HasColumnName("idPessoaDoador");

                entity.Property(e => e.PesoAproximado).HasColumnName("pesoAproximado");

                entity.Property(e => e.StatusColeta)
                    .IsRequired()
                    .HasColumnName("statusColeta")
                    .HasColumnType("enum('DISPONIVEL','SOLICITADO','ENTREGUE')")
                    .HasDefaultValueSql("'DISPONIVEL'");

                entity.Property(e => e.StatusNotificacao)
                    .IsRequired()
                    .HasColumnName("statusNotificacao")
                    .HasColumnType("enum('NENHUMA','NOTIFICADO','CONFIRMADO')")
                    .HasDefaultValueSql("'NENHUMA'");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('PAPEL','PLASTICO','VIDRO','ORGANICO','ELETRONICO','METAL')")
                    .HasDefaultValueSql("'PAPEL'");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Materialreciclavel)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_MaterialReciclavel_Empresa1");

                entity.HasOne(d => d.IdPessoaColetorNavigation)
                    .WithMany(p => p.MaterialreciclavelIdPessoaColetorNavigation)
                    .HasForeignKey(d => d.IdPessoaColetor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_MaterialReciclavel_Pessoa1");

                entity.HasOne(d => d.IdPessoaDoadorNavigation)
                    .WithMany(p => p.MaterialreciclavelIdPessoaDoadorNavigation)
                    .HasForeignKey(d => d.IdPessoaDoador)
                    .HasConstraintName("fk_MaterialReciclavel_Pessoa2");
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
