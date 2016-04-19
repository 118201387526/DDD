using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Business
{
    public class PaySystem
    {
        /// <summary>
        /// 提供账户的相关操作（余额获取，密码检测）
        /// </summary>
        public static User User { get { return new User(); } }
    }
}
