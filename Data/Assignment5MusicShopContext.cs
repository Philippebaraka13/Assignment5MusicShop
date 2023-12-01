using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment5MusicShop.Models;

namespace Assignment5MusicShop.Data
{
    public class Assignment5MusicShopContext : DbContext
    {
        public Assignment5MusicShopContext (DbContextOptions<Assignment5MusicShopContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment5MusicShop.Models.Music> Music { get; set; } = default!;
    }
}
