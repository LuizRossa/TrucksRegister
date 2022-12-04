using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrucksRegister.Interfaces;
using TrucksRegister.Models;

namespace TrucksRegister.Controllers
{
    public class TrucksController : Controller
    {
        //private readonly TrucksContext _context;
        private readonly ITrucksService _truckService;

        public TrucksController(ITrucksService truckService)
        {
            //_context = context;
            _truckService = truckService;   
        }


        // GET: Trucks
        public async Task<IActionResult> Index(string? erro)
        {
            if (erro == null)
            {
                ViewBag.erro = "";
            }
            else
            {
                ViewBag.erro = erro;
            }

            //return View(await _context.Trucks.ToListAsync());
            return View(await _truckService.GetAllTrucks());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                throw new Exception("id nulo");
            }

            var trucks = await _truckService.GetTrucksFirstOrDefault(id);

            if (trucks == null)
            {
                throw new Exception("inexistente");
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
                    _truckService.NewTruck(trucks);
                    await _truckService.SaveChanges();
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
                var trucks = await _truckService.FindById(id);
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
                return RedirectToAction("Edit", new { erro = "Modelo Inválido" });
            }

            if (trucks.ModelYear == 0)
            {
                return RedirectToAction("Edit", new { erro = "Ano Inválido" });
            }

            if (id != trucks.Id)
            {
                return RedirectToAction("Edit", new { erro = "OCORREU UM ERRO, TENTE NOVAMENTE" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _truckService.UpdateTruck(trucks);
                    await _truckService.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrucksExists(trucks.Id))
                    {
                        return RedirectToAction("Edit", new { erro = "OCORREU UM ERRO, TENTE NOVAMENTE" });
                    }
                    else
                    {
                        return RedirectToAction("Edit", new { erro = "OCORREU UM ERRO, TENTE NOVAMENTE" });
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
                throw new Exception("Objeto não encontrado");
            }

            var trucks = await _truckService.GetTrucksFirstOrDefault(id);
            if (trucks == null)
            {
                throw new Exception("Objeto não encontrado");
            }

            return View(trucks);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trucks = await _truckService.FindById(id);
            _truckService.RemoveTruck(trucks);
            await _truckService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public bool TrucksExists(int id)
        {
            return _truckService.ExistTruck(id);
        }
    }
}
