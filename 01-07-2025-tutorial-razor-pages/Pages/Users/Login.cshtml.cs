using _01_07_2025_tutorial_razor_pages.Data;
using _01_07_2025_tutorial_razor_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_07_2025_tutorial_razor_pages.Pages.Users;

public class LoginModel : PageModel
{
    private readonly _01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext _context;

    public LoginModel(_01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext context)
    {
        _context = context;
    }

    public IList<User> User { get;set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? SearchEmail { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchPassword { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var users = from m in _context.User
                    select m;
        if (!string.IsNullOrEmpty(SearchEmail) && !string.IsNullOrEmpty(SearchPassword))
        {
            var user = await users.FirstOrDefaultAsync(s => s.Email.Equals(SearchEmail) && s.Password.Equals(SearchPassword));

            if (user != null)
            {
                // Successful login - redirect to Welcome page with user id
                return RedirectToPage("./Welcome", new { id = user.Id });
            }
        }

        User = await users.ToListAsync();
        return Page();
    }
}
