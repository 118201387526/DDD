using DDD.DbContextFactory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository
{
    public class BaseRepository<T> where T : class,new()
    {
        //保证拿到的数据访问的上下文实例 线程内唯一
        protected DbContext db = EFContextFactory.GetCurrentDbContent();

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 分页查询的约束
        /// </summary>
        /// <typeparam name="S">根据谁排序</typeparam>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总页数</param>
        /// <param name="whereLambda">查询条件表达式</param>
        /// <param name="orderByLambda">排序表达式</param>
        /// <param name="isAsc">是否正序排列</param>
        /// <returns>IQueryable泛型</returns>
        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount,
                                          Expression<Func<T, bool>> whereLambda,
                                          Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var tempData = db.Set<T>().Where(whereLambda);
            totalCount = tempData.Count();
            if (isAsc)
            {
                return
                  tempData.OrderBy(orderByLambda)
                            .Skip(pageSize * (pageIndex - 1))
                            .Take(pageSize)
                            .AsQueryable();
            }
            else
            {
                return
                tempData.OrderByDescending(orderByLambda)
                            .Skip(pageSize * (pageIndex - 1))
                            .Take(pageSize)
                            .AsQueryable();
            }
        }
        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="addEntities">要添加的实体们</param>
        /// <returns>添加成功的条数</returns>
        public int AddEntities(params T[] addEntities)
        {
            var num = addEntities.Select(addEntity => db.Set<T>().Add(addEntity)).Count(temp => temp != null);
            return num;
        }

        /// <summary>
        /// 添加的实体对象
        /// </summary>
        /// <param name="addEntities">要添加的实体对象</param>
        /// <returns>添加成功的实体</returns>
        public T AddEntities(T addEntities)
        {
            var entity = db.Set<T>().Add(addEntities);
            return entity;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {

            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// 删除数据(100以内)
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns></returns>
        public bool DeleteEntity(Expression<Func<T, bool>> whereLambda)
        {
            if (db.Set<T>().Where(whereLambda).Count() > 100)
            {
                throw new Exception("数据量过大不支持");
            }
            var temp = db.Set<T>().Where(whereLambda).ToList();
            //删除数据量小的时候可以用
            foreach (var item in temp)
            {
                db.Set<T>().Attach(item);
                db.Entry(item).State = EntityState.Deleted;
            }
            return true;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <param name="isAtach">是否需要附加</param>
        /// <returns></returns>
        public bool DeleteEntity(T entity, bool isAtach)
        {
            if (isAtach)
            {
                this.DeleteEntity(entity);
            }
            else
            {
                db.Entry(entity).State = EntityState.Deleted;
            }
            return true;
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <param name="isAtach">是否需要附加</param>
        /// <returns></returns>
        public bool UpdateEntity(T entity, bool isAtach)
        {
            if (isAtach)
            {
                this.UpdateEntity(entity);
            }
            else
            {
                db.Entry(entity).State = EntityState.Detached;
            }
            return true;
        }
        /// <summary>
        /// 确定序列中的所有元素是否都满足条件。
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public bool AnyEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Any(whereLambda);
        }
    }
}
