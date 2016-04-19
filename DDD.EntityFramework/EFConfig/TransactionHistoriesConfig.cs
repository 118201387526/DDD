using DDD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.EntityFramework.EFConfig
{
    public partial class TransactionHistoriesConfig : EntityTypeConfiguration<TransactionHistories>
    {
        public TransactionHistoriesConfig()
        {
            // Primary Key
            HasKey(history => history.Id).Property(history => history.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties 没有定义成nullable类型的值类型在不主动调用IsRequired()时，数据库也是not null
            this.Property(s => s.TradeNumber).IsRequired().HasMaxLength(128);
            this.Property(s => s.Fee).HasPrecision(18, 2);
            // Relationships
        }
    }
}
