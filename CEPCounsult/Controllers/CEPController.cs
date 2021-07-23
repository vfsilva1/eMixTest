using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CEPCounsult.Data;
using CEPCounsult.Models;

namespace CEPCounsult.Controllers
{
    public class CEPController : Controller
    {
        private readonly CEPContext _context;

        public CEPController(CEPContext context)
        {
            _context = context;
        }

        // GET: CEPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CEPs.ToListAsync());
        }

        // GET: CEPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEPs
                .FirstOrDefaultAsync(m => m.CepID == id);
            if (cEP == null)
            {
                return NotFound();
            }

            return View(cEP);
        }

        // GET: CEPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CEPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CepID,Cep,Logradouro,Complemento,Bairro,Localidade,UF,Unidade,IBGE,GIA")] CEP cep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cep);
        }

        // GET: CEPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEPs.FindAsync(id);
            if (cEP == null)
            {
                return NotFound();
            }
            return View(cEP);
        }

        // POST: CEPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CepID,Cep,Logradouro,Complemento,Bairro,Localidade,UF,Unidade,IBGE,GIA")] CEP cEP)
        {
            if (id != cEP.CepID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cEP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CEPExists(cEP.CepID))
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
            return View(cEP);
        }

        // GET: CEPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEP = await _context.CEPs
                .FirstOrDefaultAsync(m => m.CepID == id);
            if (cEP == null)
            {
                return NotFound();
            }

            return View(cEP);
        }

        // POST: CEPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cEP = await _context.CEPs.FindAsync(id);
            _context.CEPs.Remove(cEP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CEPExists(int id)
        {
            return _context.CEPs.Any(e => e.CepID == id);
        }
    }
}
