﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeChange.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChangeCodeEntities : DbContext
    {
        public ChangeCodeEntities()
            : base("name=ChangeCodeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<ActionStats> ActionStats { get; set; }
        public virtual DbSet<UserAction> UserAction { get; set; }
    }
}
