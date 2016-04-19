using DDD.Model;
using DDD.TransferObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Business
{
    public static class UserAccountsExtension
    {
        internal static bool GetCurrentAccountIsActive(this UserAccounts userAccount)
        {
            return userAccount.IsActive;
        }

        internal static Money GetCurrentAccountMoney(this UserAccounts userAccount)
        {
            return new Money() { Cash = userAccount.Cash, Cashin = userAccount.EarnIncome, Check = userAccount.Earning, Coin = userAccount.Coin, Point = userAccount.Point };
        }

        internal static bool CheckPassword(this UserAccounts userAccount, string password)
        {
            return userAccount.Password == password;
        }
    }
}
