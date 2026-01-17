using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _01_07_2025_tutorial_razor_pages.Models;

namespace _01_07_2025_tutorial_razor_pages.Data
{
    public class _01_07_2025_tutorial_razor_pagesContext : DbContext
    {
        public _01_07_2025_tutorial_razor_pagesContext (DbContextOptions<_01_07_2025_tutorial_razor_pagesContext> options)
            : base(options)
        {
        }

        public DbSet<_01_07_2025_tutorial_razor_pages.Models.Movie> Movie { get; set; } = default!;
        public DbSet<_01_07_2025_tutorial_razor_pages.Models.User> User { get; set; } = default!;
    }
}
