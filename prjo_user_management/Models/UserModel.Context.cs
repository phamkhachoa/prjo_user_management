﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjo_user_management.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user_managementEntities : DbContext
    {
        public user_managementEntities()
            : base("name=user_managementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<mst_group> mst_group { get; set; }
        public virtual DbSet<mst_japan> mst_japan { get; set; }
        public virtual DbSet<tbl_detail_user_japan> tbl_detail_user_japan { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }
    }
}
