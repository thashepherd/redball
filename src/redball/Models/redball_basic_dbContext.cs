using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace redball.Models
{
    public partial class redball_basic_dbContext : DbContext
    {
        public virtual DbSet<ServiceType> TblPlServiceType { get; set; }
        public virtual DbSet<TrailerType> TblPlTrailerType { get; set; }
        public virtual DbSet<Shipper> TblShipper { get; set; }
        public virtual DbSet<ShipperRateOverride> TblShipperRateOverride { get; set; }
        public virtual DbSet<State> TblState { get; set; }
        public virtual DbSet<BenchmarkRate> TblTnsbenchmarkRate { get; set; }
        public virtual DbSet<Origin> TblOrigin { get; set; }
        public virtual DbSet<Address> TblAddress { get; set; }
        public virtual DbSet<Shipment> TblShipment { get; set; }

        public redball_basic_dbContext(DbContextOptions<redball_basic_dbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.StId)
                    .HasName("PK__tblPlSer__C33CEFC25279B2FB");

                entity.ToTable("tblPlServiceType");

                entity.Property(e => e.StId).ValueGeneratedNever();

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TrailerType>(entity =>
            {
                // TODO fix identity constraint name
                // TODO fix column width formatting
                entity.HasKey(e => e.TtId)
                    .HasName("PK__tblPlTra__FAF82DF1B16D32AF");

                entity.ToTable("tblPlTrailerType");

                // TODO negative, ghostrider
                entity.Property(e => e.TtId).ValueGeneratedNever();

                entity.Property(e => e.TtDescription).HasMaxLength(255);

                entity.Property(e => e.TtName).HasMaxLength(50);

                entity.HasOne(d => d.TrailerTypeServiceType)
                    .WithMany(p => p.TblPlTrailerType)
                    .HasForeignKey(d => d.TtStId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblPlTrailerType_TtStId");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                // TODO fix identity name
                entity.HasKey(e => e.ShipperId)
                    .HasName("PK__tblShipp__1F8AFE595863D545");

                entity.ToTable("tblShipper");

                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                // TODO fix key name
                entity.HasKey(e => e.StateCode)
                    .HasName("PK__tblState__D515E98B2EBB2806");

                entity.ToTable("tblState");

                entity.Property(e => e.StateCode).HasMaxLength(2);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.HasKey(e => e.OriginId);

                entity.ToTable("tblOrigin");

                entity.HasOne(d => d.OriginState)
                    .WithMany(p => p.OriginStateNavigation)
                    .HasForeignKey(d => d.OriginStateCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ShipperRateOverride>(entity =>
            {
                // TODO fix key name
                entity.HasKey(e => new { SroShipperId = e.SroShipperId, e.SroOriginStateCode, e.SroTargetStateCode })
                    .HasName("PK__tblShipp__C484E9E2C4F25814");

                entity.ToTable("tblShipperRateOverride");

                entity.Property(e => e.SroOriginStateCode).HasMaxLength(2);

                entity.Property(e => e.SroTargetStateCode).HasMaxLength(2);

                entity.HasOne(d => d.SroOriginState)
                    .WithMany(p => p.ShipperRateOverrideOriginStateNavigation)
                    .HasForeignKey(d => d.SroOriginStateCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SroTargetState)
                    .WithMany(p => p.ShipperRateOverrideTargetStateNavigation)
                    .HasForeignKey(d => d.SroTargetStateCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SroShipper)
                    .WithMany(p => p.ShipperRateOverrideNavigation)
                    .HasForeignKey(d => d.SroShipperId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblShipperRateOverride_SroShipperId");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId);
                entity.ToTable("tblAddress");

                entity.Property(e => e.AddressStateCode)
                    .HasMaxLength(2)
                    .IsRequired();

                entity.HasOne(d => d.AddressState)
                    .WithMany(p => p.AddressStateNavigation)
                    .HasForeignKey(d => d.AddressStateCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BenchmarkRate>(entity =>
            {
                // TODO fix key name
                entity.HasKey(e => new { e.TbrOriginStateCode, e.TbrTargetStateCode })
                    .HasName("PK__tblTNSBe__87537E3F12FF94F7");

                entity.ToTable("tblTNSBenchmarkRate");

                entity.Property(e => e.TbrOriginStateCode).HasMaxLength(2);

                entity.Property(e => e.TbrTargetStateCode).HasMaxLength(2);

                entity.Property(e => e.TbrCostPerMile).HasColumnType("decimal");

                entity.Property(e => e.TbrMinimumCharge).HasColumnType("decimal");

                //entity.HasOne(d => d.State)
                //    .WithMany(p => p.BenchmarkRateOriginStateNavigation)
                //    .HasForeignKey(d => d.TbrOriginStateCode)
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .HasConstraintName("FK_tblTNSBenchmarkRate_TbrOriginStateCode");

                //entity.HasOne(d => d.TbrTargetStateCodeNavigation)
                //    .WithMany(p => p.BenchmarkRateTargetStateNavigation)
                //    .HasForeignKey(d => d.TbrTargetStateCode)
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .HasConstraintName("FK_tblTNSBenchmarkRate_TbrTargetStateCode");
            });
        }
    }
}