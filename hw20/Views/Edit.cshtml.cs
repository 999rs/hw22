using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainBasic;
using EFRepository;

namespace hw20.Views
{
    public class EditModel : PageModel
    {
        private readonly EFRepository.DataContext _context;

        public EditModel(EFRepository.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(testClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testClassExists(testClass.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool testClassExists(int id)
        {
            return _context.testClasses.Any(e => e.Id == id);
        }
    }
}
