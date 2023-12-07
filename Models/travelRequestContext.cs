using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_TravelProject.Models
{
    public partial class travelRequestContext : DbContext
    {
        public travelRequestContext()
        {
        }

        public travelRequestContext(DbContextOptions<travelRequestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<TravelRequest> TravelRequests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=travelRequest; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dept)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("Dob")
                    .HasColumnName("Dob");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TravelRequest>(entity =>
            {
                entity.HasKey(e => e.RequestedId)
                    .HasName("PK__TravelRe__08200686B1A0B343");

                entity.ToTable("TravelRequest");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId");

                entity.Property(e => e.FromLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fromLocation");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.ToLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("toLocation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TravelRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__TravelReq__Emplo__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
