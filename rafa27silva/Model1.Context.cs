﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rafa27silva
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbArabalarEntities1 : DbContext
    {
        public dbArabalarEntities1()
            : base("name=dbArabalarEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblArabalar> TblArabalar { get; set; }
        public virtual DbSet<TblMarka> TblMarka { get; set; }
        public virtual DbSet<TblModeller> TblModeller { get; set; }
    }
}
