using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_CS_Agenda.Models
{
    public partial class ConstSoft_agendaContext : DbContext
    {
        public ConstSoft_agendaContext()
        {
        }

        public ConstSoft_agendaContext(DbContextOptions<ConstSoft_agendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<ContactoAgendum> ContactoAgenda { get; set; } = null!;
        public virtual DbSet<RolContacto> RolContactos { get; set; } = null!;
        public virtual DbSet<RolSistema> RolSistemas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6QU9F38;Database=ConstSoft_agenda;Trusted_Connection=true;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.ToTable("agenda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__agenda__user_id__4222D4EF");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("contacto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .HasColumnName("mail")
                    .IsFixedLength();

                entity.Property(e => e.NombreContact)
                    .HasMaxLength(20)
                    .HasColumnName("nombre_contact")
                    .IsFixedLength();

                entity.Property(e => e.RolId).HasColumnName("rol_id");

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
                    .HasConstraintName("FK__contacto__rol_id__3B75D760");
            });

            modelBuilder.Entity<ContactoAgendum>(entity =>
            {
                entity.ToTable("contactoAgenda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AgendaId).HasColumnName("agenda_id");

                entity.Property(e => e.ContactoId).HasColumnName("contacto_id");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.ContactoAgenda)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contactoA__agend__44FF419A");

                entity.HasOne(d => d.Contacto)
                    .WithMany(p => p.ContactoAgenda)
                    .HasForeignKey(d => d.ContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contactoA__conta__45F365D3");
            });

            modelBuilder.Entity<RolContacto>(entity =>
            {
                entity.ToTable("rolContacto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(15)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<RolSistema>(entity =>
            {
                entity.ToTable("rolSistema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(15)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos")
                    .IsFixedLength();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .HasColumnName("cedula")
                    .IsFixedLength();

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres")
                    .IsFixedLength();

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.SystemRol).HasColumnName("systemRol");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__usuario__contact__3F466844");

                entity.HasOne(d => d.SystemRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.SystemRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__systemR__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
