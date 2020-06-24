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
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public PatientsController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _uow.Patients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _uow.Patients.GetAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IIN,FullName,Address,Phone,Id")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                var createdPatient = await _uow.Patients.CreateAsync(patient);
                await _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _uow.Patients.GetAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IIN,FullName,Address,Phone,Id")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _uow.Patients.EditAsync(patient);
                    await _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _uow.Patients.GetAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _uow.Patients.GetAsync(id);
            _uow.Patients.Remove(patient);
            await _uow.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _uow.Patients.Exist(id);
        }
    }
}
