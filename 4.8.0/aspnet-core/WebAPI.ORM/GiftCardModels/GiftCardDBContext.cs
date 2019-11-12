using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.ORM.GiftCardModels
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

        public virtual DbSet<TbackendUser> TbackendUser { get; set; }
        public virtual DbSet<Tclass> Tclass { get; set; }
        public virtual DbSet<Tcoupon> Tcoupon { get; set; }
        public virtual DbSet<Tcustomer> Tcustomer { get; set; }
        public virtual DbSet<TorderProduct> TorderProduct { get; set; }
        public virtual DbSet<Tproduct> Tproduct { get; set; }
        public virtual DbSet<TproductImage> TproductImage { get; set; }
        public virtual DbSet<Trole> Trole { get; set; }
        public virtual DbSet<TsoOrder> TsoOrder { get; set; }
        public virtual DbSet<Tsupplier> Tsupplier { get; set; }

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

            modelBuilder.Entity<TbackendUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_TBACKENDUSER");

                entity.ToTable("TBackendUser");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbackendUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_TBACKEND_REFERENCE_TROLE");
            });

            modelBuilder.Entity<Tclass>(entity =>
            {
                entity.ToTable("TClass");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tcoupon>(entity =>
            {
                entity.ToTable("TCoupon");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BelongBatch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerifyTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Tcoupon)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCOUPON_REFERENCE_TCUSTOME");
            });

            modelBuilder.Entity<Tcustomer>(entity =>
            {
                entity.ToTable("TCustomer");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<TorderProduct>(entity =>
            {
                entity.ToTable("TOrderProduct");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TorderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TORDERPR_REFERENCE_TSOORDER");
            });

            modelBuilder.Entity<Tproduct>(entity =>
            {
                entity.ToTable("TProduct");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TproductImage>(entity =>
            {
                entity.ToTable("TProductImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_TROLE");

                entity.ToTable("TRole");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Permission)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TsoOrder>(entity =>
            {
                entity.ToTable("TSoOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactorPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TsoOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSOORDER_REFERENCE_TCUSTOME");
            });

            modelBuilder.Entity<Tsupplier>(entity =>
            {
                entity.ToTable("TSupplier");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FinanceContactor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinancePhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SenderPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });
        }
    }
}
