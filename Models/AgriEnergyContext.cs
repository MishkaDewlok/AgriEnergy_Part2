using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergy.Models;

public partial class AgriEnergyContext : DbContext
{
    public AgriEnergyContext()
    {
    }

    public AgriEnergyContext(DbContextOptions<AgriEnergyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeFarmer> EmployeeFarmers { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=labVMH8OX\\SQLEXPRESS;Database=AgriEnergy;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C134C9A12F9C01DD");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.EmployeePassword)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("employeePassword");
            entity.Property(e => e.EmployeeUserName)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("employeeUserName");
        });

        modelBuilder.Entity<EmployeeFarmer>(entity =>
        {
            entity.HasKey(e => e.Farmers).HasName("PK__Employee__30264D26A0DC13DE");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.FarmerId).HasColumnName("farmerID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeFarmers)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeF__emplo__5070F446");

            entity.HasOne(d => d.Farmer).WithMany(p => p.EmployeeFarmers)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__EmployeeF__farme__5165187F");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.HasKey(e => e.FarmerId).HasName("PK__Farmers__EC6F88C8E7ED87A0");

            entity.Property(e => e.FarmerId).HasColumnName("farmerID");
            entity.Property(e => e.FarmerPassword)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("farmerPassword");
            entity.Property(e => e.FarmerUserName)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("farmerUserName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D14A32C9F044");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.FarmerId).HasColumnName("farmerID");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("productCategory");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("productPrice");
            entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");
            entity.Property(e => e.ProductionDate)
                .HasColumnType("datetime")
                .HasColumnName("productionDate");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__Products__farmer__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
