using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repo
{
    public partial class WarrantyCheckerAppDBContext : DbContext
    {
        public WarrantyCheckerAppDBContext()
        {
        }

        public WarrantyCheckerAppDBContext(DbContextOptions<WarrantyCheckerAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=WarrantyCheckerAppDB;Username=postgres;Password=pingu");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.ToTable("distributors");

                entity.Property(e => e.Id)
                    .HasMaxLength(13)
                    .HasColumnName("id");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entries");

                entity.Property(e => e.Id)
                    .HasMaxLength(13)
                    .HasColumnName("id");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.Policies)
                    .HasColumnType("character varying(13)[]")
                    .HasColumnName("policies");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(13)
                    .HasColumnName("product_id");

                entity.Property(e => e.Variant)
                    .HasColumnType("json")
                    .HasColumnName("variant");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policies");

                entity.Property(e => e.Id)
                    .HasMaxLength(13)
                    .HasColumnName("id");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.DateUpdated).HasColumnName("date_updated");

                entity.Property(e => e.DistributorId)
                    .HasMaxLength(13)
                    .HasColumnName("distributor_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.YearsValid)
                    .HasPrecision(8, 2)
                    .HasColumnName("years_valid");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.DistributorId)
                    .HasConstraintName("fk_distributor");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasMaxLength(13)
                    .HasColumnName("id");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.DateUpdated).HasColumnName("date_updated");

                entity.Property(e => e.DistributorId)
                    .HasMaxLength(13)
                    .HasColumnName("distributor_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Sku).HasColumnName("sku");

                entity.Property(e => e.Variant)
                    .HasColumnType("json")
                    .HasColumnName("variant");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DistributorId)
                    .HasConstraintName("fk_distributor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
