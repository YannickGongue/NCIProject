﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCIProject.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbProjectSubEntities3 : DbContext
    {
        public DbProjectSubEntities3()
            : base("name=DbProjectSubEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TBL_AspNetRole> TBL_AspNetRole { get; set; }
        public virtual DbSet<TBL_AspNetUserRole> TBL_AspNetUserRole { get; set; }
        public virtual DbSet<TBL_COURSE> TBL_COURSE { get; set; }
        public virtual DbSet<TBL_FILE> TBL_FILE { get; set; }
        public virtual DbSet<TBL_FileType> TBL_FileType { get; set; }
        public virtual DbSet<TBL_STREAM> TBL_STREAM { get; set; }
        public virtual DbSet<TBL_STUDENT> TBL_STUDENT { get; set; }
        public virtual DbSet<TBL_SUBMISSION> TBL_SUBMISSION { get; set; }
        public virtual DbSet<TBL_SUBMISSIONDETAILS> TBL_SUBMISSIONDETAILS { get; set; }
        public virtual DbSet<TBL_SUPERVISOR> TBL_SUPERVISOR { get; set; }
        public virtual DbSet<TBL_TECHNOLOGIE> TBL_TECHNOLOGIE { get; set; }
        public virtual DbSet<TBL_USER> TBL_USER { get; set; }
    }
}
