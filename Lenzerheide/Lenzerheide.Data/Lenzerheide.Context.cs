﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lenzerheide.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LenzerheideEntities : DbContext
    {
        public LenzerheideEntities()
            : base("name=LenzerheideEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Bewertung> Bewertung { get; set; }
        public virtual DbSet<BewertungHotel> BewertungHotel { get; set; }
        public virtual DbSet<BewertungZimmer> BewertungZimmer { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Hotel_Zusatzleistung> Hotel_Zusatzleistung { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Land> Land { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Ort> Ort { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Zimmer> Zimmer { get; set; }
        public virtual DbSet<Zimmer_Zusatzleistung> Zimmer_Zusatzleistung { get; set; }
        public virtual DbSet<Zusatzleistung> Zusatzleistung { get; set; }
    }
}
