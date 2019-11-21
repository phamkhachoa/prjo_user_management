using prjo_user_management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prjo_user_management.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=user_managementEntities") { }

        public DbSet<tbl_user> TblUsers { get; set; }
        public DbSet<mst_group> MstGroups { get; set; }
        public DbSet<tbl_detail_user_japan> TblDetailJ { get; set; }
        public DbSet<mst_japan> MstJapans { get; set; }
    }


}