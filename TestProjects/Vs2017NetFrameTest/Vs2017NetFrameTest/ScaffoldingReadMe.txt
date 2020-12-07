
ASP.NET MVC core dependencies have been added to the project.
(These dependencies include packages required to enable scaffolding)

However you may still need to do make changes to your project.

1. Suggested changes to Startup class:
    1.1 Add a constructor:
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    1.2 Add MVC services:
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
       }

    1.3 Configure web app to use use Configuration and use MVC routing:

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


----------------------------------------------------------------------------------

api controller route definition

[Route("/customers/{customer_id}")]
public async Task<string> Get(string customer_id, int? page = 1, int? pageSize = 100)
{
	return "a string.";
}

Reading AppSetting Methods:

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSetting.json").Build();
            var val = configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();

It depends on the followed Packages.
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="5.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="5.0.0" />