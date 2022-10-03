using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BADC_Backend.Models
{
    public partial class BADCContext : DbContext
    {
        public BADCContext()
        {
        }

        public BADCContext(DbContextOptions<BADCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; } = null!;
        public virtual DbSet<OfficeDetail> OfficeDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BADC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("employeeDetails");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employeeID");

                entity.Property(e => e.EmployeeDesignation)
                    .HasMaxLength(50)
                    .HasColumnName("employeeDesignation");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(50)
                    .HasColumnName("employeePhone");

                entity.Property(e => e.OfficeId).HasColumnName("officeID");
            });

            modelBuilder.Entity<OfficeDetail>(entity =>
            {
                entity.HasKey(e => e.OfficeId);

                entity.ToTable("officeDetails");

                entity.Property(e => e.OfficeId)
                    .ValueGeneratedNever()
                    .HasColumnName("officeID");

                entity.Property(e => e.OfficeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("officeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
