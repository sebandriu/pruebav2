using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace demo.Models
{
    public partial class gestion_citasContext : DbContext
    {
        public gestion_citasContext()
        {
        }

        public gestion_citasContext(DbContextOptions<gestion_citasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Destinatario> Destinatarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=gestion_citas.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.ToTable("citas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("TEXT(255)")
                    .HasColumnName("descripcion");

                entity.Property(e => e.DestinatariosId).HasColumnName("destinatarios_id");

                entity.Property(e => e.Fechacita)
                    .HasColumnType("DATETIME")
                    .HasColumnName("fechacita");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.Destinatarios)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.DestinatariosId);
            });

            modelBuilder.Entity<Destinatario>(entity =>
            {
                entity.ToTable("destinatarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasColumnType("TEXT (255)")
                    .HasColumnName("correo");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("TEXT(255)")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
