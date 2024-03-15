using Ardalis.Specification.EntityFrameworkCore;
using cashop.core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace cashop.infraestructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public EfRepository(DbContext dbContext) : base(dbContext)
    {
    }
}