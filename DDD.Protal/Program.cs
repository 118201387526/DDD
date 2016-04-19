using DDD.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Protal
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = PaySystem.User;
            var money = result.BindUserId(10001).GetUserAccount();
            var isActivite = result.CheckUserIsActive();
            var setPassword = result.SetPassword("666666");
        }
    }
}
