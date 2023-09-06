using System.Text;
using AutoMapper;
using Gav.Configurations;
using Gav.Controllers.Filters;
using Gav.Data;
using Gav.Mapping;
using Gav.Models;
using Gav.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddScoped<ModelStateValidationFilter>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelStateValidationFilter>();
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "GAV Api", Version = "v1" }); });

ConfigurarAutenticacao(builder.Services);

InjecaoDepedencia(builder.Services);

var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAV Api v1"); });

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();


void InjecaoDepedencia(IServiceCollection services)
{
    services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo<IScoped>())
        .AsImplementedInterfaces()
        .WithScopedLifetime());

    services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo<ISingleton>())
        .AsImplementedInterfaces()
        .WithSingletonLifetime());
}


void ConfigurarAutenticacao(IServiceCollection services)
{
    services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 0;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    var key = Encoding.ASCII.GetBytes(Settings.Secret);

    services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
}