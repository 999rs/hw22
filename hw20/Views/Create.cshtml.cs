using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DomainBasic;
using EFRepository;

namespace hw20.Views
{
    public class CreateModel : PageModel
    {
        private readonly EFRepository.DataContext _context;

        public CreateModel(EFRepository.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public testClass testClass { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.testClasses.Add(testClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
