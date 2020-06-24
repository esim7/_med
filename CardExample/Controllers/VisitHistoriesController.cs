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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitHistory = await _uow.VisitHostories.GetAsync(id);
            if (visitHistory == null)
            {
                return NotFound();
            }

            return View(visitHistory);
        }

        //public IActionResult Create()
        //{
        //    ViewData["PatientId"] = new SelectList(_uow.Patients, "Id", "Id");
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

        // GET: VisitHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitHistory = await _uow.VisitHostories.GetAsync(id);
            if (visitHistory == null)
            {
                return NotFound();
            }
            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", visitHistory.PatientId);
            return View(visitHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,Position,Diagnose,Complaint,CreationDate,PatientId,Id")] VisitHistory visitHistory)
        {
            if (id != visitHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _uow.VisitHostories.EditAsync(visitHistory);
                    await _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitHistoryExists(visitHistory.Id))
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
            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", visitHistory.PatientId);
            return View(visitHistory);
        }

        // GET: VisitHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitHistory = await _uow.VisitHostories.GetAsync(id);
            if (visitHistory == null)
            {
                return NotFound();
            }

            return View(visitHistory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitHistory = await _uow.VisitHostories.GetAsync(id);
            _uow.VisitHostories.Remove(visitHistory);
            await _uow.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitHistoryExists(int id)
        {
            return _uow.VisitHostories.Exist(id);
        }
    }
}
