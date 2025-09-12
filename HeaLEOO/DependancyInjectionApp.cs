namespace HeaLEOO
{
    public static class DependancyInjectionApp
    {
        public static IServiceCollection AddHeaLEOOApp(this IServiceCollection services, IConfiguration configuration)
        {
            #region Authentication && Authorization
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
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IServiceAuth, ServiceAuth>();
            services.AddScoped<IServiceUserManagement, ServiceUser_Management>();
            #endregion

            #region Generic Repository & UnitOfWork
            services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
            services.AddScoped<IUnitOF_Work, UnitOF_Work>();
            #endregion

            #region AutoMapper & Helper
            services.AddAutoMapper(typeof(DependancyInjectionApp));
            services.AddScoped<IserviceSpecializations, serviceSpecializations>();
            services.AddScoped<IServiceNserv, ServiceNserv>();
            services.AddScoped<IServiceLookup, LookupService>();
            services.AddScoped<IServiceClinDate, ServiceClinDate>();
            services.AddScoped<IServiceDoctorAppointment, ServiceDoctorAppointment>();
            services.AddScoped<IServiceImage>();
            #endregion

            #region AllServices
            services.AddScoped<IServiceAuth, ServiceAuth>();
            services.AddScoped<IServicesDoctor, ServicesDoctor>();
            services.AddScoped<IServiceAppointments, ServiceAppointments>();
            services.AddScoped<IServiceSpec, ServiceSpec>();
            services.AddScoped<IServiceClinicsDB,ServiceClinicsDB>();
            services.AddScoped<IServiceLM, ServiceLM>();
            services.AddScoped<IServiceClinicsDB, ServiceClinicsDB>();
            return services;
            #endregion

        }
    }
}
