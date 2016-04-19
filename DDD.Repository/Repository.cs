
 
using DDD.Model;
using DDD.IRepository;
namespace DDD.Repository
{
   
		
	public partial class TransactionHistoriesRepository:BaseRepository<TransactionHistories>, ITransactionHistoriesRepository
    {         
    }
		
	public partial class UserAccountsRepository:BaseRepository<UserAccounts>, IUserAccountsRepository
    {         
    }
	
}