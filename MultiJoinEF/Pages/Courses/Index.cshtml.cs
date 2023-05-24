using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MultiJoinEF.Data;
using MultiJoinEF.Models;

namespace MultiJoinEF.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly MultiJoinEF.Data.ApplicationDbContext _context;

        public IndexModel(MultiJoinEF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses.ToListAsync();
            }
        }
    }
}
