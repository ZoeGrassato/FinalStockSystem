using System;
using System.Collections.Generic;
using System.Text;
using FinalSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProductModel> productModels { get; set; }
        public DbSet<ProductCategoryModel> productCategories { get; set; }
    }
}
