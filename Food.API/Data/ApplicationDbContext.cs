using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Food.API.Entities;

namespace Food.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
    public DbSet<PriceUnit> PriceUnits { get; set; }
    public DbSet<SliderAttribute> SliderAttributes { get; set; }

   
}