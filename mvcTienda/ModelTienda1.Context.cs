﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcTienda
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiendaEntities : DbContext
    {
        public TiendaEntities()
            : base("name=TiendaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<area> area { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<compra> compra { get; set; }
        public virtual DbSet<cuenta> cuenta { get; set; }
        public virtual DbSet<descuento> descuento { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<marketing> marketing { get; set; }
        public virtual DbSet<nomina> nomina { get; set; }
        public virtual DbSet<orden> orden { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<promocion> promocion { get; set; }
        public virtual DbSet<provedor> provedor { get; set; }
        public virtual DbSet<recibo> recibo { get; set; }
        public virtual DbSet<sucursal> sucursal { get; set; }
        public virtual DbSet<tienda> tienda { get; set; }
        public virtual DbSet<tipoCuenta> tipoCuenta { get; set; }
        public virtual DbSet<tipoEmpleado> tipoEmpleado { get; set; }
        public virtual DbSet<tipoProvedor> tipoProvedor { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<venta> venta { get; set; }
    }
}