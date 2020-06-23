using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Patient> Patients { get; set; }
        IRepository<VisitHistory> VisitHostories { get; set; }

        Task Save();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}