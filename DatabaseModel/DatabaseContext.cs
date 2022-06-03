using System;
using DatabaseCSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseModel
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        static DatabaseContext()
        {
            EnumFixer.MapEnums();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Desktop> Desktops { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ec2-54-228-170-125.eu-west-1.compute.amazonaws.com;Database=de1qv1gqr08u0s;Username=hysncxmhxhkwps;Password=42e0e146881cccf42a9871ecc03e3a6add375337314c4179d919d2e4577ba8b1;SslMode=Require;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "order_status", new[] { "not_sent", "sent", "delivered" })
                .HasPostgresEnum(null, "os_desktop", new[] { "Windows 7", "Windows 10", "Mac", "Linux", "Other" })
                .HasPostgresEnum(null, "os_mobile", new[] { "Android", "IOS", "Other" })
                .HasPostgresEnum(null, "product_type", new[] { "computer", "mobile", "tv", "camera" })
                .HasPostgresEnum(null, "specs_table", new[] { "Mobile", "Desktop" });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.Email, "customers_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Login, "customers_login_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Desktop>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("desktop");

                entity.Property(e => e.BatteryCapacity).HasColumnName("battery_capacity");

                entity.Property(e => e.Ethernet).HasColumnName("ethernet");

                entity.Property(e => e.Memory).HasColumnName("memory");

                entity.Property(e => e.Processor)
                    .HasMaxLength(20)
                    .HasColumnName("processor");

                entity.Property(e => e.ProcessorClockRate).HasColumnName("processor_clock_rate");

                entity.Property(e => e.ProcessorCores).HasColumnName("processor_cores");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Ram).HasColumnName("ram");

                entity.Property(e => e.ScreenDiagonal).HasColumnName("screen_diagonal");

                entity.Property(e => e.ScreenX).HasColumnName("screen_x");

                entity.Property(e => e.ScreenY).HasColumnName("screen_y");

                entity.Property(e => e.SizeX).HasColumnName("size_x");

                entity.Property(e => e.SizeY).HasColumnName("size_y");

                entity.Property(e => e.SizeZ).HasColumnName("size_z");
                
                entity.Property(e => e.OSDesktop).HasColumnName("os_desktop");
            });

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mobile");

                entity.Property(e => e.BatteryCapacity).HasColumnName("battery_capacity");

                entity.Property(e => e.Camera).HasColumnName("camera");

                entity.Property(e => e.FrontCamera).HasColumnName("front_camera");

                entity.Property(e => e.Memory).HasColumnName("memory");

                entity.Property(e => e.OpticalStabilization).HasColumnName("optical_stabilization");

                entity.Property(e => e.OsVersion).HasColumnName("os_version");

                entity.Property(e => e.Processor)
                    .HasMaxLength(20)
                    .HasColumnName("processor");

                entity.Property(e => e.ProcessorClockRate).HasColumnName("processor_clock_rate");

                entity.Property(e => e.ProcessorCores).HasColumnName("processor_cores");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Ram).HasColumnName("ram");

                entity.Property(e => e.ScreenDiagonal).HasColumnName("screen_diagonal");

                entity.Property(e => e.ScreenX).HasColumnName("screen_x");

                entity.Property(e => e.ScreenY).HasColumnName("screen_y");

                entity.Property(e => e.SizeX).HasColumnName("size_x");

                entity.Property(e => e.SizeY).HasColumnName("size_y");

                entity.Property(e => e.SizeZ).HasColumnName("size_z");
                
                entity.Property(e => e.OSMobile).HasColumnName("os_mobile");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Products)
                    .IsRequired()
                    .HasColumnName("products");
                
                entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.Name, "products_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewsNumber)
                    .HasColumnName("reviews_number")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductType).HasColumnName("product_type");
                entity.Property(e => e.SpecsTable).HasColumnName("specs_table");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("reviews");

                entity.HasIndex(e => e.CustomerId, "reviews_customer_index");

                entity.HasIndex(e => e.ProductId, "reviews_product_index");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("reviews_customer_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reviews_product_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
