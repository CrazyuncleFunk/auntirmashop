using System;
using System.Collections.Generic;
using System.Text;
using Aunt_Irma_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aunt_Irma_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        public DbSet<Item> Item { get; set; }
    }
}
