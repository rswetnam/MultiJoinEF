using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiJoinEF.Data;
using MultiJoinEF.Models;

namespace MultiJoinEF.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly MultiJoinEF.Data.ApplicationDbContext _context;

        public CreateModel(MultiJoinEF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Enrollments == null || Enrollment == null)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
