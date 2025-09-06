namespace HeaLEOO
{
    public static class DependancyInjectionApp
    {
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
            services.AddScoped<IServiceAuth, ServiceAuth>(); 
            services.AddScoped<IServicesDoctor, ServicesDoctor>();
            services.AddScoped<IserviceSpecializations, serviceSpecializations>();
            services.AddScoped<IServiceAppointments, ServiceAppointments>();
            services.AddScoped<IServiceSpec, ServiceSpec>();
            services.AddScoped<IServiceLM, ServiceLM>();
            services.AddScoped<IserviceClinics,serviceClinics>();
            services.AddScoped<IServiceClinicsDB,ServiceClinicsDB>();
            services.AddScoped<ImageService>();
            services.AddScoped<IServiceUserManagement, ServiceUserManagement>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IServiceClinic, IServiceClinic>();
            services.AddScoped<ILookupService, LookupService>();


            return services;
            

        }
    }
}
