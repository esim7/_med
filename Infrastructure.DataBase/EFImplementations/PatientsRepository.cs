using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.EFImplementations
{
    public class PatientsRepository : IRepository<Patient>
    {
        private readonly DataHospitalContext _context;

        public PatientsRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public Patient Get(int? id)
        {
            return _context.Patients.Find(id);
        }

        public IList<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient Create(Patient entity)
        {
            var patient = _context.Patients.Add(entity);
            return patient.Entity;
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
    }
}