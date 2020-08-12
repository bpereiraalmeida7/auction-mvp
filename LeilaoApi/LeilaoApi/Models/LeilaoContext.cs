using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeilaoApi.Models
{
    public partial class LeilaoContext : DbContext
    {
        public LeilaoContext(DbContextOptions<LeilaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItensLeilao> ItensLeilao { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItensLeilao>(entity =>
            {
                entity.ToTable("itens_leilao");

                entity.HasIndex(e => e.NomeItem)
                    .HasName("ix_nome_item")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataAbertura)
                    .HasColumnName("data_abertura")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataFinalizacao)
                    .HasColumnName("data_finalizacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlagUsado).HasColumnName("flag_usado");

                entity.Property(e => e.NomeItem)
                    .IsRequired()
                    .HasColumnName("nome_item")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Responsavel).HasColumnName("responsavel");

                entity.Property(e => e.ValorInicial)
                    .HasColumnName("valor_inicial")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.ResponsavelNavigation)
                    .WithMany(p => p.ItensLeilao)
                    .HasForeignKey(d => d.Responsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__itens_lei__respo__398D8EEE");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Nome)
                    .HasName("ix_nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Situacao).HasColumnName("situacao");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
