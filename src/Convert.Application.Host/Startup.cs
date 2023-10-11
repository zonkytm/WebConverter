using Convert.Application.AppServices.Contracts;
using Convert.Application.AppServices.Contracts.Handlers;
using Convert.Application.AppServices.Contracts.HttpClient;
using Convert.Application.AppServices.Handlers;
using Microsoft.Extensions.Options;

namespace Convert.Application.Host;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options => 
        {
            //options.Filters.Add<CustomValidationExceptionFilter>();
        });
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json",optional:true,reloadOnChange:true)
            .Build();
        services.Configure<CBRSettings>(configuration.GetSection("CBRSettings"));
        services.AddHttpClient();
        services.AddSingleton<IConfiguration>(configuration); 
        services.AddHealthChecks();
        services.AddSwaggerGen();
        services.AddScoped<ICBRService, CBRService>();
        services.AddScoped<ICurrencyConvertHandler,CurrencyConvertHandler>();
       

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        

        app.UseRouting();
      
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            
            endpoints.MapHealthChecks("/health");
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello world!");
            });
        });
    }
}