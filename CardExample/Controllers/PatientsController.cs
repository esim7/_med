using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardExample.Models;
using CardExample.Models.Patient;
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
        private readonly IMapper _map;

        public PatientsController(IUnitOfWork uow, IMapper map)
        {
            this._uow = uow;
            this._map = map;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _uow.Patients.GetAllAsync();
            var viewModel = _map.Map<IList<PatientViewModel>>(patients);
            return View(viewModel);
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

            var viewModel = _map.Map<PatientDetailViewModel>(patient);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(Enum.GetValues(typeof(DoctorPosition)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientRequestViewModel patientRequestView)
        {
            if (ModelState.IsValid)
            {
                var newPatient = _map.Map<Patient>(patientRequestView);
                newPatient.History = _map.Map<VisitHistory>(patientRequestView);
                var createdPatient = await _uow.Patients.CreateAsync(newPatient);
                await _uow.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(patientRequestView);
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
            var viewModel = _map.Map<PatientEditViewModel>(patient);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PatientEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var patient = _map.Map<Patient>(viewModel);
                    await _uow.Patients.EditAsync(patient);
                    await _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(viewModel.Id))
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

            var patient = await _uow.Patients.GetAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            var viewModel = _map.Map<PatientDeleteViewModel>(patient);
            return View(viewModel);
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
