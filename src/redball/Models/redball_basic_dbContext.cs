using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace redball.Models
{
    public partial class redball_basic_dbContext : DbContext
    {
        public virtual DbSet<TblPlServiceType> TblPlServiceType { get; set; }
        public virtual DbSet<TblPlTrailerType> TblPlTrailerType { get; set; }
        public virtual DbSet<TblShipper> TblShipper { get; set; }
        public virtual DbSet<TblShipperRateOverride> TblShipperRateOverride { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblTnsbenchmarkRate> TblTnsbenchmarkRate { get; set; }
        public virtual DbSet<TblOrigin> TblOrigin { get; set; }

        public redball_basic_dbContext(DbContextOptions<redball_basic_dbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPlServiceType>(entity =>
            {
                entity.HasKey(e => e.StId)
                    .HasName("PK__tblPlSer__C33CEFC25279B2FB");

                entity.ToTable("tblPlServiceType");

                entity.Property(e => e.StId).ValueGeneratedNever();

                entity.Property(e => e.StName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPlTrailerType>(entity =>
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

                entity.HasOne(d => d.TtSt)
                    .WithMany(p => p.TblPlTrailerType)
                    .HasForeignKey(d => d.TtStId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblPlTrailerType_TtStId");
            });

            modelBuilder.Entity<TblShipper>(entity =>
            {
                // TODO fix identity name
                entity.HasKey(e => e.ShipperId)
                    .HasName("PK__tblShipp__1F8AFE595863D545");

                entity.ToTable("tblShipper");

                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblOrigin>(entity =>
            {
                entity.HasKey(e => e.OId);

                entity.ToTable("tblOrigin");

                entity.Property(e => e.OStateCode)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<TblShipperRateOverride>(entity =>
            {
                // TODO fix key name
                entity.HasKey(e => new { SroShipperId = e.SroShipperId, e.SroOriginStateCode, e.SroTargetStateCode })
                    .HasName("PK__tblShipp__C484E9E2C4F25814");

                entity.ToTable("tblShipperRateOverride");

                entity.Property(e => e.SroOriginStateCode).HasMaxLength(2);

                entity.Property(e => e.SroTargetStateCode).HasMaxLength(2);

                entity.HasOne(d => d.SroShipper)
                    .WithMany(p => p.TblShipperRateOverride)
                    .HasForeignKey(d => d.SroShipperId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblShipperRateOverride_SroShipperId");

                entity.HasOne(d => d.SroOriginStateCodeNavigation)
                    .WithMany(p => p.TblShipperRateOverrideSroOriginStateCodeNavigation)
                    .HasForeignKey(d => d.SroOriginStateCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblShipperRateOverride_SroOriginStateCode");

                entity.HasOne(d => d.SroTargetStateCodeNavigation)
                    .WithMany(p => p.TblShipperRateOverrideSroTargetStateCodeNavigation)
                    .HasForeignKey(d => d.SroTargetStateCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblShipperRateOverride_SroTargetStateCode");
            });

            modelBuilder.Entity<TblState>(entity =>
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

            modelBuilder.Entity<TblTnsbenchmarkRate>(entity =>
            {
                // TODO fix key name
                entity.HasKey(e => new { e.TbrOriginStateCode, e.TbrTargetStateCode })
                    .HasName("PK__tblTNSBe__87537E3F12FF94F7");

                entity.ToTable("tblTNSBenchmarkRate");

                entity.Property(e => e.TbrOriginStateCode).HasMaxLength(2);

                entity.Property(e => e.TbrTargetStateCode).HasMaxLength(2);

                entity.Property(e => e.TbrCostPerMile).HasColumnType("decimal");

                entity.Property(e => e.TbrMinimumCharge).HasColumnType("decimal");

                entity.HasOne(d => d.TbrOriginStateCodeNavigation)
                    .WithMany(p => p.TblTnsbenchmarkRateTbrOriginStateCodeNavigation)
                    .HasForeignKey(d => d.TbrOriginStateCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblTNSBenchmarkRate_TbrOriginStateCode");

                entity.HasOne(d => d.TbrTargetStateCodeNavigation)
                    .WithMany(p => p.TblTnsbenchmarkRateTbrTargetStateCodeNavigation)
                    .HasForeignKey(d => d.TbrTargetStateCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblTNSBenchmarkRate_TbrTargetStateCode");
            });
        }
    }
}