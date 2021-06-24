using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varun_Banking.Data;
using Varun_Banking.Models;

namespace Varun_Banking.Controllers
{
    public class VarunBanksController : Controller
    {
        private readonly Varun_BankingContext _context;

        public VarunBanksController(Varun_BankingContext context)
        {
            _context = context;
        }

        // GET: VarunBanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.VarunBank.ToListAsync());
        }

        // GET: VarunBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varunBank = await _context.VarunBank
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (varunBank == null)
            {
                return NotFound();
            }

            return View(varunBank);
        }

        // GET: VarunBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VarunBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,CustomerName,AccountType,Contact,PhoneNumber,Address,Amount")] VarunBank varunBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(varunBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(varunBank);
        }

        // GET: VarunBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varunBank = await _context.VarunBank.FindAsync(id);
            if (varunBank == null)
            {
                return NotFound();
            }
            return View(varunBank);
        }

        // POST: VarunBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CustomerID,CustomerName,AccountType,Contact,PhoneNumber,Address,Amount")] VarunBank varunBank)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varunBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarunBankExists(varunBank.CustomerID))
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
            return View(varunBank);
        }

        // GET: VarunBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varunBank = await _context.VarunBank.FindAsync(id);
            if (varunBank == null)
            {
                return NotFound();
            }

            return View(varunBank);
        }

        // POST: VarunBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            VarunBank varunBank =  _context.VarunBank.Find(id);

            _context.VarunBank.Remove(varunBank);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VarunBankExists(int id)
        {
            return _context.VarunBank.Any(e => e.CustomerID == id);
        }
    }
}
