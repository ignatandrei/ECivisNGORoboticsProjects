using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECivisObj.Models
{
    public partial class NGORoboticsContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Ngouser> Ngouser { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<RoboticEntity> RoboticEntity { get; set; }
        public NGORoboticsContext(DbContextOptions<NGORoboticsContext> options)
    : base(options)

        {

        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=.;Database=NGORobotics;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressDetails)
                    .IsRequired()
                    .HasMaxLength(500);
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
                    .HasMaxLength(50);
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

            modelBuilder.Entity<RoboticEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idadress).HasColumnName("IDAdress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdadressNavigation)
                    .WithMany(p => p.RoboticEntity)
                    .HasForeignKey(d => d.Idadress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoboticEntity_Adress");
            });
        }
    }
}
