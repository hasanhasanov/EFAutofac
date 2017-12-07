using System.Data.Entity;

namespace WebDoctor.Data
{
    public interface IDoctorDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
