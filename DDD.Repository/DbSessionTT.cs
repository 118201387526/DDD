
 
using System.Text;
using DDD.IRepository;

namespace DDD.Repository
{
    public partial class DbSession :IDbSession
    {
   
	
		public ITransactionHistoriesRepository TransactionHistoriesRepository
        {
            get
            {
                return new TransactionHistoriesRepository();
            }
        }
	
		public IUserAccountsRepository UserAccountsRepository
        {
            get
            {
                return new UserAccountsRepository();
            }
        }

	}	
}