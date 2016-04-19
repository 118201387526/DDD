using DDD.EntityFramework.EFConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.EntityFramework
{
    public partial class PaymentSystemEntities : DbContext
    {
        public PaymentSystemEntities()
            : base("name=PaymentSystemEntities")
        {
            System.Data.Entity.Database.SetInitializer(CreateDatabaseWay.ChooseCreateDatabaseWay<PaymentSystemEntities>(CreateDatabaseWayType.CreateDatabaseIfNotExists));
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TransactionHistoriesConfig());
            modelBuilder.Configurations.Add(new UserAccountsConfig());
            // 禁用多对多关系表的级联删除
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
