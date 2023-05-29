using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Data.TareaModels;

namespace TareasAPI.Data;

public partial class GtareasContext : DbContext
{
    public GtareasContext()
    {
    }

    public GtareasContext(DbContextOptions<GtareasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; } = null!;

    public virtual DbSet<Tarea> Tareas { get; set; } = null!;

      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3213E83F872F9BAC");

            entity.ToTable("Administrador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminTipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pwd)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tareas__756A540249EA8598");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.EstadoEli)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estadoEli");
            entity.Property(e => e.EstadoNoCompletado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado_no_Completado");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
