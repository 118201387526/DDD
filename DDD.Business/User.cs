using DDD.Model;
using DDD.Repository;
using DDD.TransferObjectModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Business
{
    public class User
    {
        private int _userId;

        internal User()
        {

        }

        public User BindUserId(int userId)
        {
            this._userId = userId;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckUserIsActive()
        {
            return GetOne(this._userId).GetCurrentAccountIsActive();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Money GetUserAccount()
        {
            return GetOne(this._userId).GetCurrentAccountMoney();
        }

        public bool SetPassword(string password)
        {
            var dataSource = GetOne(this._userId);
            dataSource.Password = password;
            dataSource.IsActive = true;
            return DbSessionFactory.GetCurrentSession().SaveChange() > 0;
        }

        public bool CheckUserPassword(string password)
        {
            return GetOne(this._userId).CheckPassword(password);
        }

        private UserAccounts GetOne(int userId)
        {
            var dbSession = DbSessionFactory.GetCurrentSession();
            var result = dbSession.UserAccountsRepository.LoadEntities(s => s.UserId == userId).SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                result = new UserAccounts() { UserId = userId };
                dbSession.UserAccountsRepository.AddEntities(result);
                if (dbSession.SaveChange() > 0)
                    return result;
                else
                    throw new Exception("更新条目出错");
            }
        }
    }
}
