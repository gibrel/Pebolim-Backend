using Pebolim.Domain.Entities;

namespace Pebolim.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> Insert(TEntity obj);
        Task<bool> Update(TEntity obj);
        Task<bool> Delete(int id);
        Task<IList<TEntity>> Select();
        Task<TEntity> Select(int id);
    }
}
