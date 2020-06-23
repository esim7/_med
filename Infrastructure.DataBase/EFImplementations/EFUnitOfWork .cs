using System.Threading.Tasks;
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
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }
}