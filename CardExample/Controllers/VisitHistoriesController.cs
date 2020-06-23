using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace CardExample.Controllers
{
    public class VisitHistoriesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public VisitHistoriesController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _uow.VisitHostories.GetAllAsync());
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var visitHistory = await _context.VisitHistories.Include(v => v.Patient)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (visitHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(visitHistory);
        //}

        //// GET: VisitHistories/Create
        //public IActionResult Create()
        //{
        //    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FullName,Position,Diagnose,Complaint,CreationDate,PatientId,Id")] VisitHistory visitHistory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(visitHistory);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", visitHistory.PatientId);
        //    return View(visitHistory);
        //}

        //// GET: VisitHistories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var visitHistory = await _context.VisitHistories.FindAsync(id);
        //    if (visitHistory == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", visitHistory.PatientId);
        //    return View(visitHistory);
        //}

        //// POST: VisitHistories/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FullName,Position,Diagnose,Complaint,CreationDate,PatientId,Id")] VisitHistory visitHistory)
        //{
        //    if (id != visitHistory.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(visitHistory);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!VisitHistoryExists(visitHistory.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", visitHistory.PatientId);
        //    return View(visitHistory);
        //}

        //// GET: VisitHistories/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var visitHistory = await _context.VisitHistories
        //        .Include(v => v.Patient)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (visitHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(visitHistory);
        //}

        //// POST: VisitHistories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var visitHistory = await _context.VisitHistories.FindAsync(id);
        //    _context.VisitHistories.Remove(visitHistory);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool VisitHistoryExists(int id)
        //{
        //    return _context.VisitHistories.Any(e => e.Id == id);
        //}
    }
}
