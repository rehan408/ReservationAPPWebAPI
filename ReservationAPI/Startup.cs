using ReservationAPI.Models;
using Microsoft.EntityFrameworkCore;




namespace ReservationAPI;

public class Startup
{
    public string MyAloowSpecificOrigins = "_myAllowSpecificOrigins";
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
    
        services.AddControllers();
        services.AddDbContext<ReservationDBContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("ReservationsConnection"));
        });

        services.AddCors(Options =>
        {
            Options.AddPolicy(name: MyAloowSpecificOrigins, policy =>
            {
                policy.WithOrigins("http://localhost:3000");
                policy.WithMethods("http://localhost:3000");
                policy.WithHeaders("http://localhost:3000");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(MyAloowSpecificOrigins);

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}