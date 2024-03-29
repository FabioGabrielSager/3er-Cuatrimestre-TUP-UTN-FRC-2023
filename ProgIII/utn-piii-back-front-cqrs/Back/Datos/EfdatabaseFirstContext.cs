﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EjemploCQRS.Datos;

public partial class EfdatabaseFirstContext : DbContext
{
    public EfdatabaseFirstContext()
    {
    }

    public EfdatabaseFirstContext(DbContextOptions<EfdatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=conexionPersonas");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido).HasColumnName("apellido");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.TipoDocumentoId).HasColumnName("tipoDocumentoId");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_persona_tipoDocumento");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipoDocumento_pkey");

            entity.ToTable("tipoDocumento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
