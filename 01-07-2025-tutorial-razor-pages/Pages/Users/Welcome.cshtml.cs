using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _01_07_2025_tutorial_razor_pages.Data;
using _01_07_2025_tutorial_razor_pages.Models;

namespace _01_07_2025_tutorial_razor_pages.Pages.Users;

public class WelcomeModel : PageModel
{
    private readonly _01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext _context;

    public WelcomeModel(_01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext context)
    {
        _context = context;
    }

    public User User { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

        if (user is not null)
        {
            User = user;

            return Page();
        }

        return NotFound();
    }
}
