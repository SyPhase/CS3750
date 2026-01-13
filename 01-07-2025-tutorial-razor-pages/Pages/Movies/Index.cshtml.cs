using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _01_07_2025_tutorial_razor_pages.Data;
using _01_07_2025_tutorial_razor_pages.Models;

namespace _01_07_2025_tutorial_razor_pages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly _01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext _context;

        public IndexModel(_01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
