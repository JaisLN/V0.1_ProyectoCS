using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_CS_Agenda.Models
{
    public partial class p1ConstSoftContext : DbContext
    {
        public p1ConstSoftContext()
        {
        }

        public p1ConstSoftContext(DbContextOptions<p1ConstSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgendaContacto> AgendaContactos { get; set; } = null!;
        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<RolContacto> RolContactos { get; set; } = null!;
        public virtual DbSet<RolSistema> RolSistemas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6QU9F38;Database=p1ConstSoft;Trusted_Connection=true;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaContacto>(entity =>
            {
                entity.ToTable("agenda_contacto");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.AgendaId)
                    .HasMaxLength(10)
                    .HasColumnName("agenda_id")
                    .IsFixedLength();

                entity.Property(e => e.ContactoId)
                    .HasMaxLength(10)
                    .HasColumnName("contacto_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.AgendaContactos)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agenda_contacto_Agenda");

                entity.HasOne(d => d.Contacto)
                    .WithMany(p => p.AgendaContactos)
                    .HasForeignKey(d => d.ContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agenda_contacto_Contacto");
            });

            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("user_id")
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Agenda_Usuarios");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Mail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.NombreContact)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_contact");

                entity.Property(e => e.RolId)
                    .HasMaxLength(10)
                    .HasColumnName("rol_id")
                    .IsFixedLength();

                entity.Property(e => e.Telf1)
                    .HasMaxLength(10)
                    .HasColumnName("telf1")
                    .IsFixedLength();

                entity.Property(e => e.Telf2)
                    .HasMaxLength(10)
                    .HasColumnName("telf2")
                    .IsFixedLength();

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacto_RolContacto");
            });

            modelBuilder.Entity<RolContacto>(entity =>
            {
                entity.ToTable("RolContacto");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<RolSistema>(entity =>
            {
                entity.ToTable("RolSistema");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .HasColumnName("cedula")
                    .IsFixedLength();

                entity.Property(e => e.ContactId)
                    .HasMaxLength(10)
                    .HasColumnName("contact_id")
                    .IsFixedLength();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.SystemRolId)
                    .HasMaxLength(10)
                    .HasColumnName("systemRol_id")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Contacto");

                entity.HasOne(d => d.SystemRol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.SystemRolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_RolSistema");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
