﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly MultiJoinEF.Data.ApplicationDbContext _context;

        public DeleteModel(MultiJoinEF.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);

            if (course != null)
            {
                Course = course;
                _context.Courses.Remove(Course);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
