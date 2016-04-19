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
    public class UserAccountsConfig : EntityTypeConfiguration<UserAccounts>
    {
        public UserAccountsConfig()
        {
            // Primary Key
            HasKey(account => account.UserId).Property(account => account.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties 没有定义成nullable类型的值类型在不主动调用IsRequired()时，数据库也是not null
            this.Property(s => s.Point).HasPrecision(18, 0);
            // Relationships
        }
    }
}
