using Domain.Model;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Patient> Patients { get; set; }
        IRepository<VisitHistory> VisitHostories { get; set; }

        void Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}