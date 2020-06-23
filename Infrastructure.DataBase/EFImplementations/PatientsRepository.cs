using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase.EFImplementations
{
    public class PatientsRepository : IRepository<Patient>
    {
        private readonly DataHospitalContext _context;

        public PatientsRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public ValueTask<Patient> GetAsync(int? id)
        {
            return _context.Patients.FindAsync(id);
        }

        public Task<List<Patient>> GetAllAsync()
        {
            return _context.Patients.ToListAsync();
        }

        public async Task CreateAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
        }

        public Patient Edit(Patient entity)
        {
            var patient = _context.Patients.Find(entity.Id);
            if (patient != null)
            {
                patient.IIN = entity.IIN;
                patient.Address = entity.Address;
                patient.FullName = entity.FullName;
                patient.Phone = entity.Phone;
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