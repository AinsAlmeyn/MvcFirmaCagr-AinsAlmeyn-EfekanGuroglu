﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcFirmaCagrı.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbIsTakipEntities : DbContext
    {
        public DbIsTakipEntities()
            : base("name=DbIsTakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cagrilartbl> Cagrilartbl { get; set; }
        public virtual DbSet<TblAdminler> TblAdminler { get; set; }
        public virtual DbSet<TblDepartmanlar> TblDepartmanlar { get; set; }
        public virtual DbSet<TblFirmalar> TblFirmalar { get; set; }
        public virtual DbSet<TblGorevDetaylar> TblGorevDetaylar { get; set; }
        public virtual DbSet<TblGorevler> TblGorevler { get; set; }
        public virtual DbSet<TblPersoneller> TblPersoneller { get; set; }
        public virtual DbSet<CagriDetayTbl> CagriDetayTbl { get; set; }
    }
}
