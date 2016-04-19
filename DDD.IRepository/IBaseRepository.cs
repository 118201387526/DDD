using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.IRepository
{
    public interface IBaseRepository<T> where T : class,new()
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

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
        IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, S>> orderByLambda, bool isAsc);


        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="addEntities">要添加的实体们</param>
        /// <returns>添加成功的条数</returns>
        int AddEntities(params T[] addEntities);

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="addEntities">要添加的实体</param>
        /// <returns>添加成功的实体</returns>
        T AddEntities(T addEntities);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <param name="isAtach">是否需要附加</param>
        /// <returns></returns>
        bool DeleteEntity(T entity, bool isAtach);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns></returns>
        bool DeleteEntity(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <param name="isAtach">是否需要附加</param>
        /// <returns></returns>
        bool UpdateEntity(T entity, bool isAtach);

        /// <summary>
        /// 确定序列中的所有元素是否都满足条件。
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        bool AnyEntities(Expression<Func<T, bool>> whereLambda);
    }
}
