using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fptbook.Models;

public partial class FptbookStoreTeam4Context : DbContext
{
    public FptbookStoreTeam4Context()
    {
    }

    public FptbookStoreTeam4Context(DbContextOptions<FptbookStoreTeam4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TableAdmin> TableAdmins { get; set; }

    public virtual DbSet<TableAuthor> TableAuthors { get; set; }

    public virtual DbSet<TableBook> TableBooks { get; set; }

    public virtual DbSet<TableCategory> TableCategories { get; set; }

    public virtual DbSet<TableCustomer> TableCustomers { get; set; }

    public virtual DbSet<TableOrder> TableOrders { get; set; }

    public virtual DbSet<TableOrderDetail> TableOrderDetails { get; set; }

    public virtual DbSet<TablePublisher> TablePublishers { get; set; }

    public virtual DbSet<TableStoreOwner> TableStoreOwners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TBMV266\\SQLEXPRESS01; Database=FPTBookStoreTeam4; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__tableAdm__AD0500A6BA9D4097");

            entity.ToTable("tableAdmin");

            entity.Property(e => e.AdminId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("adminId");
            entity.Property(e => e.AdminAddress)
                .HasMaxLength(300)
                .HasColumnName("adminAddress");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("adminEmail");
            entity.Property(e => e.AdminName)
                .HasMaxLength(30)
                .HasColumnName("adminName");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("adminPassword");
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("adminPhone");
            entity.Property(e => e.AdminPhoto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("adminPhoto");
        });

        modelBuilder.Entity<TableAuthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__tableAut__8E2731B92F8DE8DD");

            entity.ToTable("tableAuthor");

            entity.Property(e => e.AuthorId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("authorId");
            entity.Property(e => e.AuthorAddress)
                .HasMaxLength(50)
                .HasColumnName("authorAddress");
            entity.Property(e => e.AuthorDetail)
                .HasMaxLength(300)
                .HasColumnName("authorDetail");
            entity.Property(e => e.AuthorEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("authorEmail");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(30)
                .HasColumnName("authorName");
            entity.Property(e => e.AuthorPhoto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("authorPhoto");
        });

        modelBuilder.Entity<TableBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__tableBoo__8BE5A10D6F931CF0");

            entity.ToTable("tableBook");

            entity.Property(e => e.BookId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bookId");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("authorId");
            entity.Property(e => e.BookDetail)
                .HasMaxLength(500)
                .HasColumnName("bookDetail");
            entity.Property(e => e.BookImage1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bookImage1");
            entity.Property(e => e.BookImage2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bookImage2");
            entity.Property(e => e.BookImage3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bookImage3");
            entity.Property(e => e.BookPrice)
                .HasDefaultValueSql("((10))")
                .HasColumnName("bookPrice");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(30)
                .HasColumnName("bookTitle");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.PublisherId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("publisherId");
            entity.Property(e => e.StoreOwnerId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeOwnerId");

            entity.HasOne(d => d.Author).WithMany(p => p.TableBooks)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_authorId");

            entity.HasOne(d => d.Category).WithMany(p => p.TableBooks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_categoryId");

            entity.HasOne(d => d.Publisher).WithMany(p => p.TableBooks)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_publisherId");

            entity.HasOne(d => d.StoreOwner).WithMany(p => p.TableBooks)
                .HasForeignKey(d => d.StoreOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_ownerId");
        });

        modelBuilder.Entity<TableCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tableCat__23CAF1D8C02AA9C6");

            entity.ToTable("tableCategory");

            entity.HasIndex(e => e.CategoryName, "UQ__tableCat__37077ABD620365AF").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryDetail)
                .HasMaxLength(300)
                .HasColumnName("categoryDetail");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<TableCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerEmail).HasName("PK__tableCus__FFE82D73722A7989");

            entity.ToTable("tableCustomer");

            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(300)
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerFullName)
                .HasMaxLength(60)
                .HasColumnName("customerFullName");
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("customerPassword");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
            entity.Property(e => e.CustomerPhoto)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("customerPhoto");
        });

        modelBuilder.Entity<TableOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tableOrd__0809335D4BAB4060");

            entity.ToTable("tableOrder");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerEmail");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("orderStatus");
            entity.Property(e => e.OrderTotal).HasColumnName("orderTotal");

            entity.HasOne(d => d.CustomerEmailNavigation).WithMany(p => p.TableOrders)
                .HasForeignKey(d => d.CustomerEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_customerEmail");
        });

        modelBuilder.Entity<TableOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.BookId }).HasName("primaryKeyName_orderId_bookId");

            entity.ToTable("tableOrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.BookId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bookId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Book).WithMany(p => p.TableOrderDetails)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_bookId");

            entity.HasOne(d => d.Order).WithMany(p => p.TableOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("foreignKeyName_orderId");
        });

        modelBuilder.Entity<TablePublisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__tablePub__7E8A0D969D1466E7");

            entity.ToTable("tablePublisher");

            entity.HasIndex(e => e.PublisherName, "UQ__tablePub__22E7F395C1D616A3").IsUnique();

            entity.Property(e => e.PublisherId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("publisherId");
            entity.Property(e => e.PublisherAddress)
                .HasMaxLength(50)
                .HasColumnName("publisherAddress");
            entity.Property(e => e.PublisherDetail)
                .HasMaxLength(300)
                .HasColumnName("publisherDetail");
            entity.Property(e => e.PublisherLogo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("publisherLogo");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(30)
                .HasColumnName("publisherName");
        });

        modelBuilder.Entity<TableStoreOwner>(entity =>
        {
            entity.HasKey(e => e.StoreOwnerId).HasName("PK__tableSto__232558BCEDDDF6E3");

            entity.ToTable("tableStoreOwner");

            entity.Property(e => e.StoreOwnerId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeOwnerId");
            entity.Property(e => e.StoreOwnerAddress)
                .HasMaxLength(50)
                .HasColumnName("storeOwnerAddress");
            entity.Property(e => e.StoreOwnerDetails)
                .HasMaxLength(300)
                .HasColumnName("storeOwnerDetails");
            entity.Property(e => e.StoreOwnerEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeOwnerEmail");
            entity.Property(e => e.StoreOwnerName)
                .HasMaxLength(30)
                .HasColumnName("storeOwnerName");
            entity.Property(e => e.StoreOwnerPassword)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("storeOwnerPassword");
            entity.Property(e => e.StoreOwnerPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("storeOwnerPhone");
            entity.Property(e => e.StoreOwnerPhoto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("storeOwnerPhoto");
            entity.Property(e => e.StoreOwnerTaxCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("storeOwnerTaxCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
