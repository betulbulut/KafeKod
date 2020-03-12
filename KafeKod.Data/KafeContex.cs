﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeKod.Data
{
    public class KafeContex : DbContext
    {
        public KafeContex():base("name=KafeContextConnect")
        {          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Urun>().ToTable("Urunler"); --tablo adını burada verdik

            modelBuilder.Entity<Urun>()
                    .HasMany(x => x.SiparisDetaylar)
                    .WithRequired(x => x.Urun)
                    .HasForeignKey(x=>x.UrunId)
                    .WillCascadeOnDelete(false);
        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
        

    }
}
