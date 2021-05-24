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
    public class DetailsModel : PageModel
    {
        private readonly EFRepository.DataContext _context;

        public DetailsModel(EFRepository.DataContext context)
        {
            _context = context;
        }

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
    }
}
