using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF2SQLLibrary
{
    public partial class PrsDBContext : DbContext
    {
        public PrsDBContext()
        {
        }

        public PrsDBContext(DbContextOptions<PrsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RequestLines> RequestLines { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(); //optional, must put in yourself
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=PrsDB;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.PartNbr)
                    .HasName("UQ__Products__DAFC0C1E88A8EFCA")
                    .IsUnique();

                entity.Property(e => e.Unit).HasDefaultValueSql("('Each')");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Vendor__619B8048");
            });

            modelBuilder.Entity<RequestLines>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RequestLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Produ__6E01572D");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestLines)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Reque__6D0D32F4");
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.Property(e => e.DiliveryMode).HasDefaultValueSql("('Pickup')");

                entity.Property(e => e.Status).HasDefaultValueSql("('NEW')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__UserID__6754599E");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E45045A41B")
                    .IsUnique();
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Vendors__A25C5AA7C496DC31")
                    .IsUnique();
            });
        }
    }
}
