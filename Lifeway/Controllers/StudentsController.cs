using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lifeway.Data;
using Lifeway.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lifeway.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentsDb
        [Authorize(Roles = "super_admin,admin,teacher,finance")]
        public async Task<IActionResult> AllStudents()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: StudentsDb/Details/5
        [Authorize(Roles = "super_admin,admin,teacher,finance")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.adm_no == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: StudentsDb/Create
        [Authorize(Roles = "super_admin,admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsDb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "super_admin,admin")]
        public async Task<IActionResult> Create([Bind("adm_no,name,dob,Class,date_of_admission,parent_name,parent_contact,alt_contact,status,former_school,place_of_residencen")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllStudents));
            }
            return View(students);
        }

        // GET: StudentsDb/Edit/5
        [Authorize(Roles = "super_admin,admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: StudentsDb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "super_admin,admin")]
        public async Task<IActionResult> Edit(int id, [Bind("adm_no,name,dob,Class,date_of_admission,parent_name,parent_contact,alt_contact,status,former_school,place_of_residence")] Students students)
        {
            if (id != students.adm_no)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.adm_no))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AllStudents));
            }
            return View(students);
        }

        // GET: StudentsDb/Delete/5
        [Authorize(Roles = "super_admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.adm_no == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: StudentsDb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "super_admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.FindAsync(id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllStudents));
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.adm_no == id);
        }

    }
}
