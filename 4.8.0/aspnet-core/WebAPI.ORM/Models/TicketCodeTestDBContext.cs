using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.ORM.Models
{
    public partial class TicketCodeTestDBContext : DbContext
    {
        public TicketCodeTestDBContext()
        {
        }

        public TicketCodeTestDBContext(DbContextOptions<TicketCodeTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbill> Tbill { get; set; }
        public virtual DbSet<Tclass> Tclass { get; set; }
        public virtual DbSet<Tcoupon> Tcoupon { get; set; }
        public virtual DbSet<Tcustomer> Tcustomer { get; set; }
        public virtual DbSet<Tfinance> Tfinance { get; set; }
        public virtual DbSet<Tlogin> Tlogin { get; set; }
        public virtual DbSet<Torder> Torder { get; set; }
        public virtual DbSet<Tpage> Tpage { get; set; }
        public virtual DbSet<Tproduct> Tproduct { get; set; }
        public virtual DbSet<TproductImage> TproductImage { get; set; }
        public virtual DbSet<Trole> Trole { get; set; }
        public virtual DbSet<Tsupplier> Tsupplier { get; set; }
        public virtual DbSet<Tticket> Tticket { get; set; }
        public virtual DbSet<Wcustomer> Wcustomer { get; set; }
        public virtual DbSet<WorderProduct> WorderProduct { get; set; }
        public virtual DbSet<WproductImage> WproductImage { get; set; }
        public virtual DbSet<WproductInfo> WproductInfo { get; set; }
        public virtual DbSet<Wticket> Wticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=47.98.106.199;User ID=sa;Password=Maxwell110;Database=TicketCodeTestDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tbill>(entity =>
            {
                entity.ToTable("TBill");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillContent)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillHeader)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Openbank)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tclass>(entity =>
            {
                entity.ToTable("TClass");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tcoupon>(entity =>
            {
                entity.HasKey(e => e.CouponNumber)
                    .HasName("PK_TCOUPON");

                entity.ToTable("TCoupon");

                entity.Property(e => e.CouponNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ValidityTime).HasColumnType("datetime");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Tcoupon)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_TCOUPON_REFERENCE_TTICKET");
            });

            modelBuilder.Entity<Tcustomer>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_TCUSTOMER");

                entity.ToTable("TCustomer");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContractName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SaleMan)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tfinance>(entity =>
            {
                entity.ToTable("TFinance");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Batch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tlogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_TLOGIN");

                entity.ToTable("TLogin");

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
                    .WithMany(p => p.Tlogin)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_TLOGIN_REFERENCE_TROLE");
            });

            modelBuilder.Entity<Torder>(entity =>
            {
                entity.ToTable("TOrder");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Batch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CouponNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Createtime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Receiver)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tpage>(entity =>
            {
                entity.ToTable("TPage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TicketId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tproduct>(entity =>
            {
                entity.ToTable("TProduct");

                entity.Property(e => e.Id)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Class1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Class2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryArea)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TproductImage>(entity =>
            {
                entity.ToTable("TProductImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Path)
                    .HasMaxLength(20)
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

            modelBuilder.Entity<Tsupplier>(entity =>
            {
                entity.ToTable("TSupplier");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AfterMarketPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AfterMarketer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinanceContactor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinancePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SenderPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tticket>(entity =>
            {
                entity.ToTable("TTicket");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActiveTime).HasColumnType("datetime");

                entity.Property(e => e.Batch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CouponRange)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductIdPool)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Receiver)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityEndTime).HasColumnType("datetime");

                entity.Property(e => e.ValidityStartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Wcustomer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_WCUSTOMER");

                entity.ToTable("WCustomer");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRecord)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorderProduct>(entity =>
            {
                entity.ToTable("WOrderProduct");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<WproductImage>(entity =>
            {
                entity.ToTable("WProductImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WproductInfo>(entity =>
            {
                entity.ToTable("WProductInfo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wticket>(entity =>
            {
                entity.ToTable("WTicket");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TicketCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TicketSecret)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
