//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Lifeway.Data;
//using Lifeway.Models;

//namespace Lifeway.Controllers
//{
//    public class StudentsDbController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public StudentsDbController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: StudentsDb
//        public async Task<IActionResult> AllStudents()
//        {
//            return View(await _context.Students.ToListAsync());
//        }

//        // GET: StudentsDb/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var students = await _context.Students
//                .FirstOrDefaultAsync(m => m.adm_no == id);
//            if (students == null)
//            {
//                return NotFound();
//            }

//            return View(students);
//        }

//        // GET: StudentsDb/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: StudentsDb/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Adm_no,Name,Grade,EnrollmentDate")] Students students)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(students);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(students);
//        }

//        // GET: StudentsDb/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var students = await _context.Students.FindAsync(id);
//            if (students == null)
//            {
//                return NotFound();
//            }
//            return View(students);
//        }

//        // POST: StudentsDb/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Adm_no,Name,Grade,EnrollmentDate")] Students students)
//        {
//            if (id != students.Adm_no)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(students);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentsExists(students.Adm_no))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(students);
//        }

//        // GET: StudentsDb/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var students = await _context.Students
//                .FirstOrDefaultAsync(m => m.Adm_no == id);
//            if (students == null)
//            {
//                return NotFound();
//            }

//            return View(students);
//        }

//        // POST: StudentsDb/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var students = await _context.Students.FindAsync(id);
//            _context.Students.Remove(students);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentsExists(int id)
//        {
//            return _context.Students.Any(e => e.Adm_no == id);
//        }
//    }
//}
