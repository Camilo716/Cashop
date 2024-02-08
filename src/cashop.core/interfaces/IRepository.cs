using Ardalis.Specification;

namespace cashop.core.interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T: class
{
}