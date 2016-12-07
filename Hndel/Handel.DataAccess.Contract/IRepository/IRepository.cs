using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;

namespace Handel.DataAccess.Contract.IRepository
{
    public interface IRepository<T> where T : IBaseObject
    {
        /// <summary>
        /// Dodaje obiekt do aktualnego DBsetu. Jeśli obiekt o takim Guidzie istnieje modyfikuje go.
        /// </summary>
        /// <param name="obiekt"></param>
        void Add(T obiekt);

        /// <summary>
        /// Zwraca pierwszy obiekt spełniający dany predykat
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        T FindObject(Expression<Func<T, bool>> query);
        /// <summary>
        /// Dodaje kolekcje obiektów
        /// </summary>
        /// <param name="collection"></param>
        void AddRange(ICollection<T> collection);
        /// <summary>
        /// Pobiera wszystkie obiekty tego typu z bazy.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Usuwa i zwraca istniejęcy obiekt. Zwraca null w innym przypadku.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Delete(T entity);
        /// <summary>
        /// Zwraca IQueryable wszystkich obiektów spełniający dany predykat.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        IQueryable<T> FindAll(Expression<Func<T, bool>> func);

        T Delete(Guid id);

    }
}
