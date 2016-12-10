using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;

namespace Handel.DataAccess.Contract.IRepository
{
    public interface IGenericRepository<TEntity,TId> where TEntity : BaseObject<TId>
    {
        /// <summary>
        /// Dodaje obiekt do aktualnego DBsetu. Jeśli obiekt o takim Guidzie istnieje modyfikuje go.
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Zwraca pierwszy obiekt spełniający dany predykat
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query);
        /// <summary>
        /// Pobiera wszystkie obiekty tego typu z bazy.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Usuwa i zwraca istniejęcy obiekt. Zwraca null w innym przypadku.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Delete(TEntity entity);

    }
}
