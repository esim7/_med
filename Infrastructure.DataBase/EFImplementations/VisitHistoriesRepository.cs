using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase.EFImplementations
{
    public class VisitHistoriesRepository : IRepository<VisitHistory>
    {
        private readonly DataHospitalContext _context;

        public VisitHistoriesRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public ValueTask<VisitHistory> GetAsync(int? id)
        {
            return _context.VisitHistories.FindAsync(id);
        }

        public Task<List<VisitHistory>> GetAllAsync()
        {
            return _context.VisitHistories.Include(v => v.Patient).ToListAsync();
        }

        public async Task CreateAsync(VisitHistory entity)
        {
            await _context.VisitHistories.AddAsync(entity);
        }

        public VisitHistory Edit(VisitHistory entity)
        {
            var visitHistory = _context.VisitHistories.Find(entity.Id);
            if (visitHistory != null)
            {
                visitHistory.Position = entity.Position;
                visitHistory.FullName = entity.FullName;
                visitHistory.Diagnose = entity.Diagnose;
                visitHistory.Complaint = entity.Complaint;
            }

            return visitHistory;
        }

        public void Remove(VisitHistory entity)
        {
            _context.VisitHistories.Remove(entity);
        }

        public bool Exist(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}