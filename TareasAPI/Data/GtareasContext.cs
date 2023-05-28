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

    public virtual DbSet<Tarea> Tareas { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tareas__756A540249EA8598");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.EstadoEli)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estadoEli");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
