using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostInyeccion.Models
{
    public partial class PostDbContext : DbContext
    {
        public PostDbContext()
        {
        }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=postefcore;Uid=root;Pwd=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.ToTable("alumnos");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("IX_Alumnos_IdCurso");

                entity.Property(e => e.IdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.IdCurso).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("longtext");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_Alumnos_Cursos_IdCurso");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("cursos");

                entity.HasIndex(e => e.IdProfesor)
                    .HasName("IX_Cursos_IdProfesor");

                entity.Property(e => e.IdCurso).HasColumnType("int(11)");

                entity.Property(e => e.Ciudad).HasColumnType("longtext");

                entity.Property(e => e.IdProfesor).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("longtext");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_Cursos_Profesores_IdProfesor");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.ToTable("profesores");

                entity.Property(e => e.IdProfesor).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("longtext");
            });
        }
    }
}
