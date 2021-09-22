using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFair.Data;
using JobFair.Models;
using Microsoft.AspNetCore.Http;

namespace JobFair.Controllers
{
    
    public class RegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Rid") != null)
            {
                return View(await _context.Registers.ToListAsync());
            }
            else
                return RedirectToAction("Login", "Registers");
        }


        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rid,Name,Email,Password,Role")] Register register)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Registers.Where(u => u.Email == register.Email).FirstOrDefault();
                if(account!=null)
                {
                    ModelState.AddModelError("", "Email Id Already Registered");
                    return View();
                }
                register.Password = Encryption.EncryptString(register.Password);
                _context.Add(register);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("Rid", register.Rid.ToString());
                HttpContext.Session.SetString("Name", register.Name);
                HttpContext.Session.SetString("Email", register.Email);
                HttpContext.Session.SetString("Role", register.Role);
                if (register.Role == "0")
                {
                    
                    return RedirectToAction("Create", "Companies"); 
                  
                }
                if (register.Role == "1")
                {
                    
                    return RedirectToAction("Create", "Seekers");
                }
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            register.Password = Encryption.DecryptString(register.Password);
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rid,Name,Email,Password,Role")] Register register)
        {
            if (id != register.Rid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    register.Password = Encryption.EncryptString(register.Password);
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Rid))
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
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Rid == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Register register)
        {
            Console.WriteLine(register);
            
            var account = _context.Registers.Where(u => u.Email == register.Email ).FirstOrDefault();
            account.Password = Encryption.DecryptString(account.Password);
            if (account != null && account.Password==register.Password)
            {
                HttpContext.Session.SetString("Rid", account.Rid.ToString());
                HttpContext.Session.SetString("Name", account.Name);
                HttpContext.Session.SetString("Email", account.Email);
                HttpContext.Session.SetString("Role", account.Role);
                if (account.Role=="0")
                    return RedirectToAction("dashboard","Companies");
                if (account.Role == "1")
                    return RedirectToAction("dashboard", "Seekers");
                if (account.Role == "2")
                    return RedirectToAction("Index");// after successfull login user will be redirected to this 
            }
            else
            {
                ModelState.AddModelError("", register.Password);
            }
            return View();
        }


        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Registers.FindAsync(id);
            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return RedirectToPage("/Index"); // in index page we will show list of registered users
        }

        private bool RegisterExists(int id)
        {
            return _context.Registers.Any(e => e.Rid == id);
        }
    }
}
