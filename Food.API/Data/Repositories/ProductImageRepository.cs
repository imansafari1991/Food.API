using Food.API.Data.Intefaces;
using Food.API.DTOs.Product;
using Food.API.Entities;
using Food.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Food.API.Data.Repositories;

public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    
}