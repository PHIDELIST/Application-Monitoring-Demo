using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using api.Services.PrometheusService;
using Microsoft.OpenApi.Models;
using Prometheus;
public class Program
{
    protected Program() { }
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var allowOriginsPolicy = "origin";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: allowOriginsPolicy, b =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    b.AllowAnyOrigin();
                }

                b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((_) => true);
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddScoped<IPrometheusService, PrometheusService>();

        builder.Services.AddProblemDetails();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        var app = builder.Build();

        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors(allowOriginsPolicy);
        app.UseHttpMetrics(); // Expose default HTTP request metrics

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }

        app.MapGet("/", () => true);

        app.MapControllers();
        app.MapMetrics(); // Expose the /metrics endpoint
        app.Run();
    }
}