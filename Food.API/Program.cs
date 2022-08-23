using System;
using System.Reflection;
using System.Text;
using Food.API.Data;
using Food.API.Data.Intefaces;
using Food.API.Data.Repositories;
using Food.API.Entities;
using Food.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation  
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Food Web API",
        Description = "Authentication and Authorization in Food Web API with JWT and Swagger"
    });

    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",

        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
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

            new string[] {}

        }
    });

    swagger.EnableAnnotations();
    //swagger.IncludeXmlComments(filePath);
});

builder.Services.AddCors(options=>

    options.AddPolicy("Policy", builder =>
    
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    )

);
builder.Services.AddHttpContextAccessor();

// Adding Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })

// Adding Jwt Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience =builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefualtConnection")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
InitializeDb(builder.Configuration.GetConnectionString("DefualtConnection"));
builder.Services.AddScoped<SliderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddTransient<FileService>();


builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<ISliderAttributeRepository, SliderAttributeRepository>();

builder.Services.AddScoped<IProductRepository, ProductRopsitory>();
builder.Services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryAttributeRepository, CategoryAttributeRepository>();


builder.Services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("Policy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
static void InitializeDb(string connectionString)
{
    var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseNpgsql(connectionString).Options;
    using var context = new ApplicationDbContext(dbOptions);

    if (!context.Languages.Any())
    {
        var languages = new List<Language>
        {
            new() {Id = 1,Title = "English", Code = "en", IsActive = true,CreatedDateTime = DateTime.UtcNow},
            new() {Id = 2, Title = "Armanian", Code = "arm", IsActive = true,CreatedDateTime = DateTime.UtcNow},
            new() {Id = 3, Title = "Russian", Code = "ru", IsActive = true,CreatedDateTime = DateTime.UtcNow},

        };

        context.Languages.AddRange(languages);
        context.SaveChanges();
    }
    
}