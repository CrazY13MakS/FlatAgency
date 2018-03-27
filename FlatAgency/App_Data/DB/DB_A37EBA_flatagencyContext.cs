using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlatAgency.App_Data.DB
{
    public partial class DB_A37EBA_flatagencyContext : DbContext
    {
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Flat> Flat { get; set; }
        public virtual DbSet<FlatClass> FlatClass { get; set; }
        public virtual DbSet<Street> Street { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=SQL6004.site4now.net;Initial Catalog=DB_A37EBA_flatagency;User Id=DB_A37EBA_flatagency_admin;Password=Sonyst23I;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Flat>(entity =>
            {
                entity.Property(e => e.FlatId).HasColumnName("flat_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDelete)
                    .HasColumnName("date_delete")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlatClassId).HasColumnName("flat_class_id");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasColumnName("house_number")
                    .HasMaxLength(250);

                entity.Property(e => e.ImagePath).HasColumnName("image_path");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Rooms).HasColumnName("rooms");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.FlatClass)
                    .WithMany(p => p.Flat)
                    .HasForeignKey(d => d.FlatClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flat_fk1");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Flat)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flat_fk0");
            });

            modelBuilder.Entity<FlatClass>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__FlatClas__72E12F1B53B80216")
                    .IsUnique();

                entity.Property(e => e.FlatClassId).HasColumnName("flat_class_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Street)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Street_fk0");
            });
        }
    }
}
