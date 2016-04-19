using DDD.DbContextFactory;
using DDD.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository
{
    public partial class DbSession : IDbSession
    {
        /// <summary>
        /// 让当前数据库访问层跟数据库的会话中所有的修改全部提交到数据库中
        /// </summary>
        /// <returns></returns>
        public int SaveChange()
        {
            return EFContextFactory.GetCurrentDbContent().SaveChanges();
        }
    }
}
