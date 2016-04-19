using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DbContextFactory
{
    public class EFContextFactory
    {
        /// <summary>
        /// 对数据库访问上下文实例进行管理，保证线程内实例唯一
        /// </summary>
        /// <returns>当前数据访问对象</returns>
        public static DbContext GetCurrentDbContent()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("DbContext");
            if (dbContext == null)
            {
                dbContext = new DDD.EntityFramework.PaymentSystemEntities();//改变这里的实例那么数据访问层的所有EF上下文都会变化
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
