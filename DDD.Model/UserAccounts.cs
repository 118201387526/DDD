using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Model
{
    public class UserAccounts
    {
        public int UserId { get; set; }

        public decimal Point { get; set; }

        public decimal Coin { get; set; }

        public decimal Cash { get; set; }

        public decimal EarnIncome { get; set; }

        public decimal Earning { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }
    }
}
