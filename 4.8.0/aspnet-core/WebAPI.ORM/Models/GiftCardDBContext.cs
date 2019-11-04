using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.ORM.Models
{
    public partial class GiftCardDBContext : DbContext
    {
        public GiftCardDBContext()
        {
        }

        public GiftCardDBContext(DbContextOptions<GiftCardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tcustomer> Tcustomer { get; set; }
        public virtual DbSet<TdeliveryAddress> TdeliveryAddress { get; set; }
        public virtual DbSet<TgiftCard> TgiftCard { get; set; }
        public virtual DbSet<TorderProduct> TorderProduct { get; set; }
        public virtual DbSet<Tproduct> Tproduct { get; set; }
        public virtual DbSet<TproductImage> TproductImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=47.98.106.199;User ID=sa;Password=Maxwell110;Database=GiftCardDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tcustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_TCUSTOMER");

                entity.ToTable("TCustomer");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TdeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.DeliveryId)
                    .HasName("PK_TDELIVERYADDRESS");

                entity.ToTable("TDeliveryAddress");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Custom)
                    .WithMany(p => p.TdeliveryAddress)
                    .HasForeignKey(d => d.CustomId)
                    .HasConstraintName("FK_TDELIVER_REFERENCE_TCUSTOME");
            });

            modelBuilder.Entity<TgiftCard>(entity =>
            {
                entity.HasKey(e => e.GiftCardId)
                    .HasName("PK_TGIFTCARD");

                entity.ToTable("TGiftCard");

                entity.Property(e => e.GiftCardId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Record)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TicketCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TicketSecret)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TgiftCard)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_TGIFTCAR_REFERENCE_TCUSTOME");
            });

            modelBuilder.Entity<TorderProduct>(entity =>
            {
                entity.ToTable("TOrderProduct");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DiscountPrice)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GiftCardId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OriginPrice)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.GiftCard)
                    .WithMany(p => p.TorderProduct)
                    .HasForeignKey(d => d.GiftCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TORDERPR_REFERENCE_TGIFTCAR");
            });

            modelBuilder.Entity<Tproduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_TPRODUCT");

                entity.ToTable("TProduct");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SkuCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TproductImage>(entity =>
            {
                entity.HasKey(e => e.ProductImageId)
                    .HasName("PK_TPRODUCTIMAGE");

                entity.ToTable("TProductImage");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TproductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPRODUCT_REFERENCE_TPRODUCT");
            });
        }
    }
}
