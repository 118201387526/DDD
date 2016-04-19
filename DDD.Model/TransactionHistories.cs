using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Model
{
    public class TransactionHistories
    {
        public int Id { get; set; }

        public string TradeNumber { get; set; }

        public DateTime TradeTime { get; set; }

        public decimal Fee { get; set; }

        public int TradeUserId { get; set; }

        public string Remark { get; set; }

        public int TradeState { get; set; }
    }
}
