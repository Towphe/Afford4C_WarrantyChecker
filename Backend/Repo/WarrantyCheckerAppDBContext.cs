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
                    .HasMaxLength(11)
                    .HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Barangay)
                    .HasMaxLength(50)
                    .HasColumnName("barangay");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Contactperson)
                    .HasMaxLength(100)
                    .HasColumnName("contactperson");

                entity.Property(e => e.Dateadded).HasColumnName("dateadded");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Lastupdated).HasColumnName("lastupdated");

                entity.Property(e => e.Mobilenumber)
                    .HasMaxLength(12)
                    .HasColumnName("mobilenumber");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasColumnName("region");

                entity.Property(e => e.Telephonenumber)
                    .HasMaxLength(9)
                    .HasColumnName("telephonenumber");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entries");

                entity.Property(e => e.Id)
                    .HasMaxLength(11)
                    .HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Barangay)
                    .HasMaxLength(50)
                    .HasColumnName("barangay");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Contactnumber)
                    .HasMaxLength(12)
                    .HasColumnName("contactnumber");

                entity.Property(e => e.Dateadded).HasColumnName("dateadded");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Lastupdated).HasColumnName("lastupdated");

                entity.Property(e => e.Postalcode).HasColumnName("postalcode");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(11)
                    .HasColumnName("product_id");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("productname");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .HasColumnName("region");

                entity.Property(e => e.Variant)
                    .HasColumnType("json")
                    .HasColumnName("variant");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasMaxLength(11)
                    .HasColumnName("id");

                entity.Property(e => e.Dateadded).HasColumnName("dateadded");

                entity.Property(e => e.DistributorId)
                    .HasMaxLength(11)
                    .HasColumnName("distributor_id");

                entity.Property(e => e.Lastupdated).HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku");

                entity.Property(e => e.Variant)
                    .HasColumnType("json")
                    .HasColumnName("variant");

                entity.Property(e => e.Warrantyperiod)
                    .HasMaxLength(10)
                    .HasColumnName("warrantyperiod");

                entity.Property(e => e.Warrantyunit).HasColumnName("warrantyunit");

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
