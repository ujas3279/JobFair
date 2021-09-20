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
    public class SelecetedCandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelecetedCandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SelecetedCandidates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SelecetedCandidates.Include(s => s.Company).Include(s => s.Seeker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SelecetedCandidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selecetedCandidate = await _context.SelecetedCandidates
                .Include(s => s.Company)
                .Include(s => s.Seeker)
                .FirstOrDefaultAsync(m => m.Scid == id);
            if (selecetedCandidate == null)
            {
                return NotFound();
            }

            return View(selecetedCandidate);
        }

        // GET: SelecetedCandidates/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink");
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification");
            return View();
        }

        // POST: SelecetedCandidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Scid,Cid,Sid")] SelecetedCandidate selecetedCandidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selecetedCandidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", selecetedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", selecetedCandidate.Sid);
            return View(selecetedCandidate);
        }

        // GET: SelecetedCandidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selecetedCandidate = await _context.SelecetedCandidates.FindAsync(id);
            if (selecetedCandidate == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", selecetedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", selecetedCandidate.Sid);
            return View(selecetedCandidate);
        }

        // POST: SelecetedCandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Scid,Cid,Sid")] SelecetedCandidate selecetedCandidate)
        {
            if (id != selecetedCandidate.Scid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selecetedCandidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelecetedCandidateExists(selecetedCandidate.Scid))
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
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", selecetedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", selecetedCandidate.Sid);
            return View(selecetedCandidate);
        }

        // GET: SelecetedCandidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selecetedCandidate = await _context.SelecetedCandidates
                .Include(s => s.Company)
                .Include(s => s.Seeker)
                .FirstOrDefaultAsync(m => m.Scid == id);
            if (selecetedCandidate == null)
            {
                return NotFound();
            }

            return View(selecetedCandidate);
        }

        // POST: SelecetedCandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selecetedCandidate = await _context.SelecetedCandidates.FindAsync(id);
            _context.SelecetedCandidates.Remove(selecetedCandidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelecetedCandidateExists(int id)
        {
            return _context.SelecetedCandidates.Any(e => e.Scid == id);
        }
    }
}
