using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFcoreexample1.Models;

public partial class KaniniContext : DbContext
{
    public KaniniContext()
    {
    }

    public KaniniContext(DbContextOptions<KaniniContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-BE5N6B8;database=KANINI;integrated security=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("employee");

        //    entity.Property(e => e.EmpId).HasColumnName("empID");
        //    entity.Property(e => e.EmpName)
        //        .HasMaxLength(25)
        //        .IsUnicode(false)
        //        .HasColumnName("empName");
        //    entity.Property(e => e.EmpSalary)
        //        .HasColumnType("decimal(7, 2)")
        //        .HasColumnName("empSalary");
        //});

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED49C4C24F");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
