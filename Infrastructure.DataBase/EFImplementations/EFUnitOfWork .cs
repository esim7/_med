using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.EFImplementations
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private readonly DataHospitalContext _context;

        public IRepository<Patient> Patients { get; set; }
        public IRepository<VisitHistory> VisitHostories { get; set; }

        public EFUnitOfWork(IRepository<Patient> patients, 
                             IRepository<VisitHistory> visitHostories,
                             DataHospitalContext context)
        {
            this.Patients = patients;
            this.VisitHostories = visitHostories;
            this._context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }
    }
}