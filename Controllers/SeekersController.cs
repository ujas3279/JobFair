using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFair.Data;
using JobFair.Models;

namespace JobFair.Controllers
{
    public class SeekersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeekersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seekers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seekers.Include(s => s.Register);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seekers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seekers
                .Include(s => s.Register)
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (seeker == null)
            {
                return NotFound();
            }

            return View(seeker);
        }

        // GET: Seekers/Create
        public IActionResult Create()
        {
            ViewData["Rid"] = new SelectList(_context.Registers, "Rid", "Email");
            return View();
        }

        // POST: Seekers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,SeekerName,HighestQualification,Percentage,Skills,Status,Rid")] Seeker seeker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Rid"] = new SelectList(_context.Registers, "Rid", "Email", seeker.Rid);
            return View(seeker);
        }

        // GET: Seekers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seekers.FindAsync(id);
            if (seeker == null)
            {
                return NotFound();
            }
            ViewData["Rid"] = new SelectList(_context.Registers, "Rid", "Email", seeker.Rid);
            return View(seeker);
        }

        // POST: Seekers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sid,SeekerName,HighestQualification,Percentage,Skills,Status,Rid")] Seeker seeker)
        {
            if (id != seeker.Sid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeekerExists(seeker.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Rid"] = new SelectList(_context.Registers, "Rid", "Email", seeker.Rid);
            return View(seeker);
        }

        // GET: Seekers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeker = await _context.Seekers
                .Include(s => s.Register)
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (seeker == null)
            {
                return NotFound();
            }

            return View(seeker);
        }

        // POST: Seekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seeker = await _context.Seekers.FindAsync(id);
            _context.Seekers.Remove(seeker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeekerExists(int id)
        {
            return _context.Seekers.Any(e => e.Sid == id);
        }
    }
}
