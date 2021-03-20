using Financije.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financije.Persistence
{
    public class FinancijeContext : DbContext
    {
        public FinancijeContext(DbContextOptions<FinancijeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancijeContext).Assembly);

            modelBuilder.Entity<Accounts>()
                .HasKey(a => new { a.StoreId, a.DescriptionId });

            modelBuilder.Entity<Accounts>()
                .HasOne(p => p.Store)
                .WithMany(b => b.Accounts)
                .HasForeignKey(p => p.StoreId);

            modelBuilder.Entity<Accounts>()
                .HasOne(p => p.Description)
                .WithMany(b => b.Accounts)
                .HasForeignKey(p => p.DescriptionId);

            modelBuilder.Entity<Accounts>()
                .Property(p => p.Payin)
                .HasDefaultValue(0);

            modelBuilder.Entity<Accounts>()
                .Property(p => p.Payout)
                .HasDefaultValue(0);


            modelBuilder.Entity<Articles>()
                .HasKey(a => new { a.DescriptionId });

            modelBuilder.Entity<Articles>()
                .HasOne(p => p.Description)
                .WithMany(b => b.Articles)
                .HasForeignKey(p => p.DescriptionId);

        }
        public DbSet<Descriptions> Descriptions { get; set; }

        public DbSet<Articles> Articles { get; set; }

        public DbSet<Stores> Stores { get; set; }


    }
}
