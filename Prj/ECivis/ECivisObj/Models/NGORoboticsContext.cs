using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECivisObj.Models
{
    public partial class NGORoboticsContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Benefits> Benefits { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<Ngouser> Ngouser { get; set; }
        public virtual DbSet<PhoneNumbers> PhoneNumbers { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<RoboticEntity> RoboticEntity { get; set; }
        public virtual DbSet<Social> Social { get; set; }

        // Unable to generate entity type for table 'dbo.RoboticEntityProjects'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NGORobotics;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressDetails)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Benefits>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IdroboticEntity).HasColumnName("IDRoboticEntity");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.IdroboticEntityNavigation)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.IdroboticEntity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Benefits_RoboticEntity");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ContactDetails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Website).HasMaxLength(200);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ContactDetails)
                    .HasForeignKey<ContactDetails>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactDetails_Emails");
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IdcontactDetails).HasColumnName("IDContactDetails");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ngouser>(entity =>
            {
                entity.ToTable("NGOUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<PhoneNumbers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdcontactDetails).HasColumnName("IDContactDetails");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdcontactDetailsNavigation)
                    .WithMany(p => p.PhoneNumbers)
                    .HasForeignKey(d => d.IdcontactDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhoneNumbers_ContactDetails");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdroboticEntity).HasColumnName("IDRoboticEntity");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdroboticEntityNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdroboticEntity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photos_RoboticEntity");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<RoboticEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.IdcontactDetails).HasColumnName("IDContactDetails");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdaddressNavigation)
                    .WithMany(p => p.RoboticEntity)
                    .HasForeignKey(d => d.Idaddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoboticEntity_Adress");

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.RoboticEntity)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoboticEntity_Category");

                entity.HasOne(d => d.IdcontactDetailsNavigation)
                    .WithMany(p => p.RoboticEntity)
                    .HasForeignKey(d => d.IdcontactDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoboticEntity_ContactDetails");
            });

            modelBuilder.Entity<Social>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.IdcontactDetails).HasColumnName("IDContactDetails");

                entity.Property(e => e.Network)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdcontactDetailsNavigation)
                    .WithMany(p => p.Social)
                    .HasForeignKey(d => d.IdcontactDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Social_ContactDetails");
            });
        }
    }
}
