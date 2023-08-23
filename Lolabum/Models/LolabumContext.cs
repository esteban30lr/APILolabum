﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lolabum.Models;

public partial class LolabumContext : DbContext
{
    public LolabumContext()
    {
    }

    public LolabumContext(DbContextOptions<LolabumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concescionario> Concescionarios { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<VistaPedidoConDato> VistaPedidoConDatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VVT0133; Database=lolabum; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA54D70D355");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__23A341303B336EE4");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ID_PERSONA");
        });

        modelBuilder.Entity<Concescionario>(entity =>
        {
            entity.HasKey(e => e.IdConcesionario).HasName("PK__CONCESCI__A797951AD0EB92E8");

            entity.ToTable("CONCESCIONARIO");

            entity.Property(e => e.IdConcesionario).HasColumnName("ID_CONCESIONARIO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__922CA26946E93ADE");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ID_PERSONA_EMPLEADO");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__FACTURA__4A921BEDA54B8147");

            entity.ToTable("FACTURA");

            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("FECHA_FACTURA");
            entity.Property(e => e.State).HasColumnName("STATE");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__PEDIDO__A05C2F2A29322B6B");

            entity.ToTable("PEDIDO");

            entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.IdVehiculos).HasColumnName("ID_VEHICULOS");
            entity.Property(e => e.Pedido1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PEDIDO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ID_CLIENTE");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ID_FACTURA");

            entity.HasOne(d => d.IdVehiculosNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdVehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ID_VEHICULOS");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__PERSONA__782441495CE5C66D");

            entity.ToTable("PERSONA");

            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_2");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Identificacion).HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Nombre1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_1");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_2");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculos).HasName("PK__VEHICULO__CD63295547D803F5");

            entity.ToTable("VEHICULOS");

            entity.Property(e => e.IdVehiculos).HasColumnName("ID_VEHICULOS");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.IdConcesionario).HasColumnName("ID_CONCESIONARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("PK_ID_CATEGORIA");

            entity.HasOne(d => d.IdConcesionarioNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdConcesionario)
                .HasConstraintName("PK_ID_CONCESIONARIO");
        });

        modelBuilder.Entity<VistaPedidoConDato>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaPedidoConDatos");

            entity.Property(e => e.ClienteApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLIENTE_APELLIDO");
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLIENTE_NOMBRE");
            entity.Property(e => e.ConcesionarioDireccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONCESIONARIO_DIRECCION");
            entity.Property(e => e.ConcesionarioNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONCESIONARIO_NOMBRE");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("FECHA_FACTURA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdConcesionario).HasColumnName("ID_CONCESIONARIO");
            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");
            entity.Property(e => e.IdVehiculos).HasColumnName("ID_VEHICULOS");
            entity.Property(e => e.Pedido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PEDIDO");
            entity.Property(e => e.VehiculoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICULO_NOMBRE");
            entity.Property(e => e.VehiculoPrecio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICULO_PRECIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
