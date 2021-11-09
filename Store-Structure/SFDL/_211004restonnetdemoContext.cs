using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SFModels;

#nullable disable

namespace SFDL
{
    public partial class _211004restonnetdemoContext : DbContext
    {
        public _211004restonnetdemoContext()
        {
        }

        public _211004restonnetdemoContext(DbContextOptions<_211004restonnetdemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Line_Item> LineItems { get; set; }
        public virtual DbSet<Order> OrderLists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID)
                    .HasName("cus_PK");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerID).HasColumnName("cus_customerID");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("customer_email");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone");
            });

            modelBuilder.Entity<Line_Item>(entity =>
            {
                entity.HasKey(e => e.lineItemProductNameID)
                    .HasName("lin_PK");

                entity.ToTable("LineItem");

                entity.Property(e => e.lineItemProductNameID)
                    .ValueGeneratedNever()
                    .HasColumnName("line_itemnameID");

                entity.Property(e => e.Quantity).HasColumnName("line_itemquantity");

                entity.Property(e => e.LineOrderListID).HasColumnName("line_orderListID");

                entity.Property(e => e.LineStoreID).HasColumnName("line_storeID");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.LineItem)
                    .HasForeignKey<Line_Item>(d => d.lineItemProductNameID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lin_pro_FK");

                entity.HasOne(d => d.LineOrderList)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.LineOrderListID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lin_ord_FK");

                entity.HasOne(d => d.LineStore)
                    .WithMany(p => p.Line_Items)
                    .HasForeignKey(d => d.LineStoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lin_sto_FK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderList)
                    .HasName("ord_PK");

                entity.ToTable("OrderList");

                entity.Property(e => e.OrderList).HasColumnName("order_orderListID");

                //entity.Property(e => e.OrderCus).HasColumnName("order_customerID");

                entity.Property(e => e.StoreID).HasColumnName("order_storeID");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("order_totalprice")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.OrderCus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ord_cus_FK");

                entity.HasOne(d => d.OrderStore)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ord_sto_FK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID)
                    .HasName("pro_PK");

                entity.ToTable("Product");

                entity.Property(e => e.ProductID).HasColumnName("product_productnameID");

                entity.Property(e => e.ProductCategory)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("product_category");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("money")
                    .HasColumnName("product_price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.StoreStoreID).HasColumnName("store_storeID");

                entity.HasOne(d => d.StoreStore)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreStoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pro_sto_FK");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.StoreFrontID)
                    .HasName("sto_PK");

                entity.ToTable("StoreFront");

                entity.HasIndex(e => e.StoreFrontAddress, "sto_UC_address")
                    .IsUnique();

                entity.HasIndex(e => e.StoreFrontName, "sto_UC_name")
                    .IsUnique();

                entity.Property(e => e.StoreFrontID).HasColumnName("store_storeID");

                entity.Property(e => e.StoreFrontAddress)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreFrontName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
