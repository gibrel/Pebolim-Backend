using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySQLContext _mySQLContext;

        public BaseRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public virtual async Task<bool> Insert(TEntity obj)
        {
            try
            {
                _mySQLContext.Set<TEntity>().Add(obj);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public virtual async Task<IList<TEntity>> Select()
        {
            var entities = _mySQLContext.Set<TEntity>().ToList();
            return entities;
        }

        public virtual async Task<TEntity?> Select(int id)
            => _mySQLContext.Set<TEntity>().SingleOrDefault(x => x.Id == id);

        public virtual async Task<bool> Update(TEntity obj)
        {
            try
            {
                _mySQLContext.Entry(obj).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                _mySQLContext.Set<TEntity>().Remove(await Select(id));
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
