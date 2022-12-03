using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrucksRegister.Models;

namespace TrucksRegister.Controllers
{
    public class TrucksController : Controller
    {
        private readonly TrucksContext _context;

        public TrucksController(TrucksContext context)
        {
            _context = context;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trucks.ToListAsync());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trucks = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trucks == null)
            {
                return NotFound();
            }

            return View(trucks);
        }

        // GET: Trucks/Create
        public IActionResult Create(string? erro)
        {
            if (erro == null)
            {
                ViewBag.erro = "";
            }
            else
            {
                ViewBag.erro = erro;
            }

            try
            {
                TruckModel addModel = new TruckModel();
                ViewBag.Model = new SelectList(addModel.getAllTruckModels(), "Model", "Model");
                ModelYear modelYear = new ModelYear();
                ViewBag.modelYear = new SelectList(modelYear.getAllModelYears(), "Year", "Year");
                return View();
            }
            catch(Exception ex) 
            {
                return RedirectToAction("Index", new { erro = "ERRO, TENTE NOVAMENTE" });
            }
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,ManufacturingYear,ModelYear")] Trucks trucks)
        {
            if (trucks.Model != "FH" && trucks.Model != "FM")
            {
                return RedirectToAction("Create", new { erro = "Modelo Inválido" });
            }

            if (trucks.ModelYear == 0)
            {
                return RedirectToAction("Create", new { erro = "Ano Inválido"});
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(trucks);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    return RedirectToAction("Create", new { erro = ex.ToString() });
                }
            }
            return View(trucks);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var trucks = await _context.Trucks.FindAsync(id);
                if (trucks == null)
                {
                    return RedirectToAction("Index", new { erro = "Caminhão não encontrado" });
                }

                TruckModel addModel = new TruckModel();
                ViewBag.Model = new SelectList(addModel.getAllTruckModels(), "Model", "Model", trucks.Model);

                ModelYear modelYear = new ModelYear();
                ViewBag.modelYear = new SelectList(modelYear.getAllModelYears(), "Year", "Year", trucks.ModelYear);

                return View(trucks);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { erro = "Id não encontrado" });
            }
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,ManufacturingYear,ModelYear")] Trucks trucks)
        {
            if (trucks.Model != "FH" && trucks.Model != "FM")
            {
                return RedirectToAction("Create", new { erro = "Modelo Inválido" });
            }

            if (trucks.ModelYear == 0)
            {
                return RedirectToAction("Create", new { erro = "Ano Inválido" });
            }

            if (id != trucks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trucks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrucksExists(trucks.Id))
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
            return View(trucks);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trucks = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trucks == null)
            {
                return NotFound();
            }

            return View(trucks);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trucks = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(trucks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrucksExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
