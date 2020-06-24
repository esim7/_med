using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.DataBase.EFImplementations
{
    public class PatientsRepository : IRepository<Patient>
    {
        private readonly DataHospitalContext _context;

        public PatientsRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public Task<Patient> GetAsync(int? id)
        {
            return _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Patient>> GetAllAsync()
        {
            return _context.Patients.ToListAsync();
        }

        public ValueTask<EntityEntry<Patient>> CreateAsync(Patient entity)
        {
            var createdPatient =  _context.Patients.AddAsync(entity);
            return createdPatient;
        }

        public ValueTask<Patient> EditAsync(Patient entity)
        {
            var patient = _context.Patients.FindAsync(entity.Id);
            if (patient != null)
            {
                patient.Result.IIN = entity.IIN;
                patient.Result.Address = entity.Address;
                patient.Result.FullName = entity.FullName;
                patient.Result.Phone = entity.Phone;
            }
            return patient;
        }

        public void Remove(Patient entity)
        {
            _context.Patients.Remove(entity);
        }

        public bool Exist(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}