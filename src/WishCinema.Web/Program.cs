using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WishCinema.Application.Services;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Persistence;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        //TODO: גûםוסעט ג מעהוכüםûי לועמה
        builder.Services.AddScoped<MainDbContext>();
        builder.Services.AddScoped<IUserManagerService, UserManagerService>();
        builder.Services.AddScoped<ICinemasService, CinemasService>();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>(); 
        builder.Services.AddScoped<IAuditUserProvider, AuditUserProvider>();
        builder.Services.AddScoped<ITicketsService, TicketsService>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "bearer {token}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}