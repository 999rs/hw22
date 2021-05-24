using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DomainBasic;
using EFRepository;

namespace hw20.Views
{
    public class DeleteModel : PageModel
    {
        private readonly EFRepository.DataContext _context;

        public DeleteModel(EFRepository.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public testClass testClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            testClass = await _context.testClasses.FirstOrDefaultAsync(m => m.Id == id);

            if (testClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            testClass = await _context.testClasses.FindAsync(id);

            if (testClass != null)
            {
                _context.testClasses.Remove(testClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
