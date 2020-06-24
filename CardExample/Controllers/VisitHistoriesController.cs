using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardExample.Models.VisitHistory;
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
        private readonly IMapper _mapper;

        public VisitHistoriesController(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var visitHistories = await _uow.VisitHostories.GetAllAsync();
            var viewModel = _mapper.Map<IList<VisitHistoryViewModel>>(visitHistories);
            return View(viewModel);
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
            var viewModel = _mapper.Map<VisitHistoryDetailsViewModel>(visitHistory);
            return View(viewModel);
        }

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
            ViewBag.Doctors = new SelectList(Enum.GetValues(typeof(DoctorPosition)));
            var viewModel = _mapper.Map<VisitHistoryEditViewModel>(visitHistory);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,Position,Diagnose,Complaint,CreationDate,PatientId,Id")] VisitHistoryEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }
            var visitHistory = _mapper.Map<VisitHistory>(viewModel);
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
            return View(viewModel);
        }

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
            var viewModel = _mapper.Map<VisitHistoryDeleteVewModel>(visitHistory);
            return View(viewModel);
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
