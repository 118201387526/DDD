
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DDD.IRepository
{
    public partial interface  IDbSession:IUnitWork
    {
   
		
		ITransactionHistoriesRepository TransactionHistoriesRepository { get; }
		
		IUserAccountsRepository UserAccountsRepository { get; }
	}	
}