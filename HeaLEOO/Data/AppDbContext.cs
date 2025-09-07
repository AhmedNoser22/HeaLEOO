namespace HeaLEOO.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        public DbSet<Doctors> Doctors { get; set; } = default!;
        public DbSet<Specializations> Specializations { get; set; } = default!;
        public DbSet<Clinics> Clinics { get; set; } = default!;
        public DbSet<ClinicDoctors> ClinicDoctors { get; set; } = default!;
        public DbSet<Appointments> Appointments { get; set; } = default!;
        public DbSet<ModelService> Services { get; set; } = default!;
    }
}
