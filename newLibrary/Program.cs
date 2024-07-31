using newLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using newLibrary.Models.Entities;
using newLibrary.Helpers;
using System.Security.Cryptography.Xml;
using newLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = ".NET 8 Web API"
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \\r\\n\\r\\n Enter 'Bearer' [space] and then your token in the text input below.\\r\\n\\r\\nExample: \\\"Bearer 12345abcdef\\\"\"",
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
    }
});

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddDbContext<newLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    /*builder.Services.AddAuthorization();*/

  /*  builder.Services.AddIdentityApiEndpoints<IdentityUser>()
        .AddEntityFrameworkStores<newLibraryDbContext>();*/

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    /*app.MapIdentityApi<IdentityUser>();*/

    app.UseMiddleware<JwtMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
});

/*public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // other configurations
    }*/

