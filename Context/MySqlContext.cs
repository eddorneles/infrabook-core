using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using InfraBook.Models;

namespace InfraBook.Context
{
    public partial class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atributo> Atributo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoEmpresa> EstadoEmpresa { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<ItemConfiguracao> ItemConfiguracao { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Regional> Regional { get; set; }
        public virtual DbSet<SendEmail> SendEmail { get; set; }
        public virtual DbSet<Setor> Setor { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SubTipo> SubTipo { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<TipoDado> TipoDado { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoUnidade> TipoUnidade { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }
        public virtual DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public virtual DbSet<UnidadeSetor> UnidadeSetor { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySQL("server=172.30.255.10;port=3306;user=root;password=mysql@a7f1h4e1;database=infrabook");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Atributo>(entity =>
            {
                entity.ToTable("atributo", "infrabook");

                entity.HasIndex(e => e.ItemConfiguracaoId)
                    .HasName("fk_atributos_item_configuracao1_idx");

                entity.HasIndex(e => e.TipoDadoId)
                    .HasName("fk_atributos_tipo_dado1_idx");

                entity.HasIndex(e => e.UnidadeMedidaId)
                    .HasName("fk_atributos_unidade_medida1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemConfiguracaoId)
                    .HasColumnName("item_configuracao_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDadoId)
                    .HasColumnName("tipo_dado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnidadeMedidaId)
                    .HasColumnName("unidade_medida_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemConfiguracao)
                    .WithMany(p => p.Atributo)
                    .HasForeignKey(d => d.ItemConfiguracaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_atributos_item_configuracao1");

                entity.HasOne(d => d.TipoDado)
                    .WithMany(p => p.Atributo)
                    .HasForeignKey(d => d.TipoDadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_atributos_tipo_dado1");

                entity.HasOne(d => d.UnidadeMedida)
                    .WithMany(p => p.Atributo)
                    .HasForeignKey(d => d.UnidadeMedidaId)
                    .HasConstraintName("fk_atributos_unidade_medida1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoEmpresa>(entity =>
            {
                entity.HasKey(e => new { e.EstadoId, e.EmpresaId });

                entity.ToTable("estado_empresa", "infrabook");

                entity.HasIndex(e => e.EmpresaId)
                    .HasName("fk_estado_has_empresa_empresa1_idx");

                entity.HasIndex(e => e.EstadoId)
                    .HasName("fk_estado_has_empresa_estado1_idx");

                entity.Property(e => e.EstadoId)
                    .HasColumnName("estado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("empresa_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.EstadoEmpresa)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estado_has_empresa_empresa1");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.EstadoEmpresa)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estado_has_empresa_estado1");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento", "infrabook");

                entity.HasIndex(e => e.ItenConfiguracaoId)
                    .HasName("fk_eventos_iten_configuracao1_idx");

                entity.HasIndex(e => e.TipoEventoId)
                    .HasName("fk_eventos_tipo_evento1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Custo)
                    .HasColumnName("custo")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.DataCompetencia)
                    .HasColumnName("data_competencia")
                    .HasColumnType("date");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("date");

                entity.Property(e => e.ItenConfiguracaoId)
                    .HasColumnName("iten_configuracao_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEventoId)
                    .HasColumnName("tipo_evento_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ItenConfiguracao)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.ItenConfiguracaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventos_iten_configuracao1");

                entity.HasOne(d => d.TipoEvento)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.TipoEventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventos_tipo_evento1");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.ToTable("fornecedor", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo", "infrabook");

                entity.HasIndex(e => e.GrupoId)
                    .HasName("fk_grupo_grupo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrupoId)
                    .HasColumnName("grupo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.InverseGrupoNavigation)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("fk_grupo_grupo1");
            });

            modelBuilder.Entity<ItemConfiguracao>(entity =>
            {
                entity.ToTable("item_configuracao", "infrabook");

                entity.HasIndex(e => e.EmpresaId)
                    .HasName("fk_item_configuracao_empresa1_idx");

                entity.HasIndex(e => e.FornecedorId)
                    .HasName("fk_item_configuracao_fornecedor1_idx");

                entity.HasIndex(e => e.GrupoId)
                    .HasName("fk_item_configuracao_grupo1_idx");

                entity.HasIndex(e => e.MunicipioId)
                    .HasName("fk_item_configuracao_municipio1_idx");

                entity.HasIndex(e => e.SubTipoId)
                    .HasName("fk_item_configuracao_sub_tipo1_idx");

                entity.HasIndex(e => e.UnidadeSetorId)
                    .HasName("fk_item_configuracao_unidade_setor1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("empresa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FornecedorId)
                    .HasColumnName("fornecedor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrupoId)
                    .HasColumnName("grupo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MunicipioId)
                    .HasColumnName("municipio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SubTipoId)
                    .HasColumnName("sub_tipo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnidadeSetorId)
                    .HasColumnName("unidade_setor_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_configuracao_empresa1");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.FornecedorId)
                    .HasConstraintName("fk_item_configuracao_fornecedor1");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_configuracao_grupo1");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_configuracao_municipio1");

                entity.HasOne(d => d.SubTipo)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.SubTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_configuracao_sub_tipo1");

                entity.HasOne(d => d.UnidadeSetor)
                    .WithMany(p => p.ItemConfiguracao)
                    .HasForeignKey(d => d.UnidadeSetorId)
                    .HasConstraintName("fk_item_configuracao_unidade_setor1");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acao)
                    .IsRequired()
                    .HasColumnName("acao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasColumnName("mensagem")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("municipio", "infrabook");

                entity.HasIndex(e => e.RegionalId)
                    .HasName("fk_municipio_regional1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RegionalId)
                    .HasColumnName("regional_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Regional)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.RegionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_municipio_regional1");
            });

            modelBuilder.Entity<Regional>(entity =>
            {
                entity.ToTable("regional", "infrabook");

                entity.HasIndex(e => e.EstadoId)
                    .HasName("fk_regional_estado1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstadoId)
                    .HasColumnName("estado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Regional)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_regional_estado1");
            });

            modelBuilder.Entity<SendEmail>(entity =>
            {
                entity.ToTable("send_email", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Destinatario)
                    .IsRequired()
                    .HasColumnName("destinatario")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasColumnName("mensagem")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Remetente)
                    .IsRequired()
                    .HasColumnName("remetente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.ToTable("setor", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubTipo>(entity =>
            {
                entity.ToTable("sub_tipo", "infrabook");

                entity.HasIndex(e => e.SubTipoId)
                    .HasName("fk_sub_tipo_sub_tipo1_idx");

                entity.HasIndex(e => e.TipoId)
                    .HasName("fk_sub_tipo_tipo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SubTipoId)
                    .HasColumnName("sub_tipo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoId)
                    .HasColumnName("tipo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.SubTipoNavigation)
                    .WithMany(p => p.InverseSubTipoNavigation)
                    .HasForeignKey(d => d.SubTipoId)
                    .HasConstraintName("fk_sub_tipo_sub_tipo1");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.SubTipo)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sub_tipo_tipo1");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDado>(entity =>
            {
                entity.ToTable("tipo_dado", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.ToTable("tipo_evento", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUnidade>(entity =>
            {
                entity.ToTable("tipo_unidade", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.ToTable("unidade", "infrabook");

                entity.HasIndex(e => e.EmpresaId)
                    .HasName("fk_unidade_empresa1_idx");

                entity.HasIndex(e => e.MunicipioId)
                    .HasName("fk_unidade_municipio1_idx");

                entity.HasIndex(e => e.TipoUnidadeId)
                    .HasName("fk_unidade_tipo_unidade1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("empresa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MunicipioId)
                    .HasColumnName("municipio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUnidadeId)
                    .HasColumnName("tipo_unidade_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unidade_empresa1");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unidade_municipio1");

                entity.HasOne(d => d.TipoUnidade)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.TipoUnidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unidade_tipo_unidade1");
            });

            modelBuilder.Entity<UnidadeMedida>(entity =>
            {
                entity.ToTable("unidade_medida", "infrabook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadeSetor>(entity =>
            {
                entity.HasKey(e => e.UnidadeSetor1);

                entity.ToTable("unidade_setor", "infrabook");

                entity.HasIndex(e => e.SetorId)
                    .HasName("fk_unidade_has_setor_setor1_idx");

                entity.HasIndex(e => e.UnidadeId)
                    .HasName("fk_unidade_has_setor_unidade1_idx");

                entity.Property(e => e.UnidadeSetor1)
                    .HasColumnName("unidade_setor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SetorId)
                    .HasColumnName("setor_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnidadeId)
                    .HasColumnName("unidade_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Setor)
                    .WithMany(p => p.UnidadeSetor)
                    .HasForeignKey(d => d.SetorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unidade_has_setor_setor1");

                entity.HasOne(d => d.Unidade)
                    .WithMany(p => p.UnidadeSetor)
                    .HasForeignKey(d => d.UnidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unidade_has_setor_unidade1");
            });
        }
    }
}
