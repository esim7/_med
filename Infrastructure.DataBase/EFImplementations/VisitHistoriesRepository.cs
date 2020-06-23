using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.EFImplementations
{
    public class VisitHistoriesRepository : IRepository<VisitHistory>
    {
        private readonly DataHospitalContext _context;

        public VisitHistoriesRepository(DataHospitalContext context)
        {
            this._context = context;
        }

        public VisitHistory Get(int? id)
        {
            return _context.VisitHistories.Find(id);
        }

        public IList<VisitHistory> GetAll()
        {
            return _context.VisitHistories.ToList();
        }

        public VisitHistory Create(VisitHistory entity)
        {
            var visitHistory = _context.VisitHistories.Add(entity);
            return visitHistory.Entity;
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
    }
}