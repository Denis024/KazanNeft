﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KazanNeft.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IgishevKazanNeft2Entities : DbContext
    {
        private static IgishevKazanNeft2Entities _context;

        public IgishevKazanNeft2Entities()
            : base("name=IgishevKazanNeft2Entities")
        {
        }

        public static IgishevKazanNeft2Entities GetContext()
        {
            if (_context == null)
                _context = new IgishevKazanNeft2Entities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AssetGroups> AssetGroups { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<ChangedParts> ChangedParts { get; set; }
        public virtual DbSet<DepartmentLocations> DepartmentLocations { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmergencyMaintenances> EmergencyMaintenances { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
    }
}
