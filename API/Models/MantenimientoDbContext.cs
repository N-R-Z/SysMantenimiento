using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class MantenimientoDbContext : DbContext
{
    public MantenimientoDbContext()
    {
    }

    public MantenimientoDbContext(DbContextOptions<MantenimientoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Propiedad> Propiedads { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-JGGJ636\\SQLEXPRESS;database=MantenimientoDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mantenim__3214EC2760C85BE5");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.PropiedadId).HasColumnName("PropiedadID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.Propiedad).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.PropiedadId)
                .HasConstraintName("FK__Mantenimi__Propi__5DCAEF64");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Mantenimi__Prove__5CD6CB2B");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC27C03306E4");

            entity.ToTable("Notificacion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasMaxLength(255);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Notificac__Usuar__619B8048");
        });

        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Propieda__3214EC27C5926E90");

            entity.ToTable("Propiedad");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Propiedads)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Propiedad__Usuar__4D94879B");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC2729C07030");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC2744534ABB");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053450DD8263").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
