using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Toysworld.Models;

public partial class ToysShopContext : DbContext
{
    public ToysShopContext()
    {
    }

    public ToysShopContext(DbContextOptions<ToysShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<Toy> Toys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASMAR;Database=ToysShop;Trusted_Connection=True;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funds__3214EC07653F8C2E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FundPrice)
                .HasColumnType("money")
                .HasColumnName("Fund_price");
        });

        modelBuilder.Entity<Toy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Toys__3214EC07B8AA615C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.ToyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Toy_name");
            entity.Property(e => e.TypeOfToy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Type_of_toy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
