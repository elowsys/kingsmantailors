using KingsmanTailors.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KingsmanTailors.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }

        public DbSet<Fabric> Fabrics { get; set; }

        public DbSet<FrontStyle> FrontStyles { get; set; }

        public DbSet<LapelStyle> LapelStyles { get; set; }

        public DbSet<OccasionFit> OccasionFittings { get; set; }

        public DbSet<OccasionLabel> OccasionLabels { get; set; }

        public DbSet<OccasionStyle> OccasionStyles { get; set; }

        public DbSet<OccasionType> OccasionTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SalesTag> SalesTags { get; set; }

        public DbSet<Suit> Suits { get; set; }

        public DbSet<SuitDetail> SuitDetails { get; set; }

        public DbSet<SuitSize> SuitSizes { get; set; }

        public DbSet<SuitType> SuitTypes { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<VentStyle> VentStyles { get; set; }

        public DbSet<Value> Values { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //set table name for each entity
            builder.Entity<Appointment>().ToTable("datAppointment");
            builder.Entity<AppointmentDetail>().ToTable("datAppointmentDetail");
            builder.Entity<Fabric>().ToTable("infFabric");
            builder.Entity<FrontStyle>().ToTable("infFrontStyle");
            builder.Entity<LapelStyle>().ToTable("infLapelStyle");
            builder.Entity<OccasionFit>().ToTable("infOccasionFit");
            builder.Entity<OccasionLabel>().ToTable("infOccasionLabel");
            builder.Entity<OccasionStyle>().ToTable("infOccasionStyle");
            builder.Entity<OccasionType>().ToTable("infOccasionType");
            builder.Entity<Role>().ToTable("datRole");
            builder.Entity<SalesTag>().ToTable("infSalesTag");
            builder.Entity<Suit>().ToTable("datSuit");
            builder.Entity<SuitDetail>().ToTable("datSuitDetail");
            builder.Entity<SuitSize>().ToTable("infSuitSize");
            builder.Entity<SuitType>().ToTable("infSuitType");
            builder.Entity<UserRole>().ToTable("datUserRole");
            builder.Entity<User>().ToTable("datUser");
            builder.Entity<VentStyle>().ToTable("infVentStyle");

            base.OnModelCreating(builder);
        }
    }
}
