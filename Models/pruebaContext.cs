using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models;

public partial class pruebaContext : DbContext
{
    public pruebaContext()
    {
    }

    public pruebaContext(DbContextOptions<pruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ErrorsLog> ErrorsLogs { get; set; }

    public virtual DbSet<Habito> Habitos { get; set; }

    public virtual DbSet<Spresult> Spresults { get; set; }

    public virtual DbSet<VwErrorsLog> VwErrorsLogs { get; set; }

    public virtual DbSet<VwHabito> VwHabitos { get; set; }

    public virtual DbSet<VwSpresult> VwSpresults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=20.22.200.198,1444;initial catalog=Prueba;user id=DirectorTIC;password=Seguridad01*;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ErrorsLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ErrorsLo__3214EC07F16C0BB1");

            entity.ToTable("ErrorsLog");

            entity.Property(e => e.Clue).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionMessage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionStackTrace).IsUnicode(false);
            entity.Property(e => e.ExceptionType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MethodName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Habitos__3214EC0788983599");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Crea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modifica");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("Id_Usuario_crea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("Id_Usuario_Modifica");
        });

        modelBuilder.Entity<Spresult>(entity =>
        {
            entity.ToTable("SPResult");

            entity.Property(e => e.Action).HasMaxLength(50);
        });

        modelBuilder.Entity<VwErrorsLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ErrorsLog");

            entity.Property(e => e.Clue).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionMessage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionStackTrace).IsUnicode(false);
            entity.Property(e => e.ExceptionType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MethodName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwHabito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Habitos");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCrea)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Crea");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modifica");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("Id_Usuario_crea");
            entity.Property(e => e.IdUsuarioModifica).HasColumnName("Id_Usuario_Modifica");
        });

        modelBuilder.Entity<VwSpresult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SPResult");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
