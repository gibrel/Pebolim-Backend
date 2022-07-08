using Microsoft.EntityFrameworkCore;
using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public virtual async Task<bool> Insert(TEntity obj)
        {
            try
            {
                await _mySqlContext.Set<TEntity>().AddAsync(obj);
                _mySqlContext.SaveChanges();
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
            var entities = await _mySqlContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity?> Select(int id)
        {
            try
            {
                var entity = await _mySqlContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public virtual async Task<bool> Update(TEntity obj)
        {
            try
            {
                _mySqlContext.Entry(obj).State = EntityState.Modified;
                await _mySqlContext.SaveChangesAsync();
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
                var entity = await Select(id);

                if (entity == null)
                    return false;

                _mySqlContext.Set<TEntity>().Remove(entity);
                _mySqlContext.SaveChanges();
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
