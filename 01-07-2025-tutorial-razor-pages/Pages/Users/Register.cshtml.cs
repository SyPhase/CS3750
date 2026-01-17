using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01_07_2025_tutorial_razor_pages.Data;
using _01_07_2025_tutorial_razor_pages.Models;

namespace _01_07_2025_tutorial_razor_pages.Pages.Users;

public class RegisterModel : PageModel
{
    private readonly _01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext _context;

    public RegisterModel(_01_07_2025_tutorial_razor_pages.Data._01_07_2025_tutorial_razor_pagesContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public User User { get; set; } = default!;

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.User.Add(User);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Login");
    }
}
