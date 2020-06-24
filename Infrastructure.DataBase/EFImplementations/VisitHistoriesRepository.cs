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
    public class VisitHistoriesRepository : IRepository<VisitHistory>
    {
        private readonly DataHospitalContext _context;

        public VisitHistoriesRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public Task<VisitHistory> GetAsync(int? id)
        {
            return _context.VisitHistories.Include(v => v.Patient).FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<List<VisitHistory>> GetAllAsync()
        {
            return _context.VisitHistories.Include(v => v.Patient).ToListAsync();
        }

        public ValueTask<EntityEntry<VisitHistory>> CreateAsync(VisitHistory entity)
        {
            var createdHistory =  _context.VisitHistories.AddAsync(entity);
            return createdHistory;
        }

        public ValueTask<VisitHistory> EditAsync(VisitHistory entity)
        {
            var visitHistory = _context.VisitHistories.FindAsync(entity.Id);
            if (visitHistory != null)
            {
                visitHistory.Result.Position = entity.Position;
                visitHistory.Result.FullName = entity.FullName;
                visitHistory.Result.Diagnose = entity.Diagnose;
                visitHistory.Result.Complaint = entity.Complaint;
            }

            return visitHistory;
        }

        public void Remove(VisitHistory entity)
        {
            _context.VisitHistories.Remove(entity);
        }

        public bool Exist(int id)
        {
            return _context.VisitHistories.Any(e => e.Id == id);
        }
    }
}