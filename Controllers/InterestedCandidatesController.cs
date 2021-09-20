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
    public class InterestedCandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestedCandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestedCandidates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InterestedCandidates.Include(i => i.Company).Include(i => i.Seeker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InterestedCandidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestedCandidate = await _context.InterestedCandidates
                .Include(i => i.Company)
                .Include(i => i.Seeker)
                .FirstOrDefaultAsync(m => m.Icid == id);
            if (interestedCandidate == null)
            {
                return NotFound();
            }

            return View(interestedCandidate);
        }

        // GET: InterestedCandidates/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink");
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification");
            return View();
        }

        // POST: InterestedCandidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Icid,Cid,Sid")] InterestedCandidate interestedCandidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestedCandidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", interestedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", interestedCandidate.Sid);
            return View(interestedCandidate);
        }

        // GET: InterestedCandidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestedCandidate = await _context.InterestedCandidates.FindAsync(id);
            if (interestedCandidate == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", interestedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", interestedCandidate.Sid);
            return View(interestedCandidate);
        }

        // POST: InterestedCandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Icid,Cid,Sid")] InterestedCandidate interestedCandidate)
        {
            if (id != interestedCandidate.Icid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestedCandidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestedCandidateExists(interestedCandidate.Icid))
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
            ViewData["Cid"] = new SelectList(_context.Companies, "Cid", "ApplyLink", interestedCandidate.Cid);
            ViewData["Sid"] = new SelectList(_context.Seekers, "Sid", "HighestQualification", interestedCandidate.Sid);
            return View(interestedCandidate);
        }

        // GET: InterestedCandidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interestedCandidate = await _context.InterestedCandidates
                .Include(i => i.Company)
                .Include(i => i.Seeker)
                .FirstOrDefaultAsync(m => m.Icid == id);
            if (interestedCandidate == null)
            {
                return NotFound();
            }

            return View(interestedCandidate);
        }

        // POST: InterestedCandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interestedCandidate = await _context.InterestedCandidates.FindAsync(id);
            _context.InterestedCandidates.Remove(interestedCandidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestedCandidateExists(int id)
        {
            return _context.InterestedCandidates.Any(e => e.Icid == id);
        }
    }
}
