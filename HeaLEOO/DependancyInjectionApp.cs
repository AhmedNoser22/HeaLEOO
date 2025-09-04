namespace HeaLEOO
{
    public static class DependancyInjectionApp
    {
        //bbbbbbbb
        public static IServiceCollection AddHeaLEOOApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>
                (
                    options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 6;
                        options.User.RequireUniqueEmail = true;
                        options.SignIn.RequireConfirmedEmail = false;
                    }
                )
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            services.AddAutoMapper(typeof(DependancyInjectionApp));
            services.AddScoped<IServiceDoctors, ServiceDoctors>();
            services.AddScoped<IClinicsService, ClinicsService>();

            return services;
        }
    }
}
