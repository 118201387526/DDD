using DDD.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Repository
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentSession()
        {
            //确定session对象线程内唯一
            IDbSession dbSession = CallContext.GetData("DbSession") as IDbSession;
            if (dbSession == null)
            {
                dbSession = new DbSession(); //更改这里全局的都Repository对象都会发生变化
                CallContext.SetData("DbSession", dbSession);
            }
            return dbSession;
        }
    }
}
