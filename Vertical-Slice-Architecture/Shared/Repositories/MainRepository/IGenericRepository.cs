namespace Vertical_Slice_Architecture.Shared.Repositories.MainRepository;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    Task<T> UpdateAsync(T entity);
}