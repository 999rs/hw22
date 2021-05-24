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
    public class IndexModel : PageModel
    {
        private readonly EFRepository.DataContext _context;

        public IndexModel(EFRepository.DataContext context)
        {
            _context = context;
        }

        public IList<testClass> testClass { get;set; }

        public async Task OnGetAsync()
        {
            testClass = await _context.testClasses.ToListAsync();
        }
    }
}
