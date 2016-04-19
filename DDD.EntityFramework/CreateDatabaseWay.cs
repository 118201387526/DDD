using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.EntityFramework
{

    public static class CreateDatabaseWay
    {
        public static IDatabaseInitializer<T> ChooseCreateDatabaseWay<T>(CreateDatabaseWayType createDatabaseWayType)
            where T : System.Data.Entity.DbContext
        {
            switch (createDatabaseWayType)
            {
                case CreateDatabaseWayType.DropCreateDatabaseAlways:
                    return new MyDropCreateDatabaseAlways<T>();
                case CreateDatabaseWayType.DropCreateDatabaseIfModelChanges:
                    return new MyDropCreateDatabaseIfModelChanges<T>();
                case CreateDatabaseWayType.CreateDatabaseIfNotExists:
                default:
                    return new MyCreateDatabaseIfNotExists<T>();
            }
        }
    }
    public enum CreateDatabaseWayType
    {
        DropCreateDatabaseAlways = 1,
        DropCreateDatabaseIfModelChanges = 2,
        CreateDatabaseIfNotExists = 3,
    }
    public class MyDropCreateDatabaseAlways<T> : DropCreateDatabaseAlways<T>
        where T : System.Data.Entity.DbContext
    {
        protected override void Seed(T context)
        {

            InitializationInfo.Initialization<T>(context);
        }
    }
    public class MyDropCreateDatabaseIfModelChanges<T> : DropCreateDatabaseIfModelChanges<T>
        where T : System.Data.Entity.DbContext
    {
        protected override void Seed(T context)
        {

            InitializationInfo.Initialization<T>(context);
        }
    }
    public class MyCreateDatabaseIfNotExists<T> : CreateDatabaseIfNotExists<T>
        where T : System.Data.Entity.DbContext
    {
        protected override void Seed(T context)
        {
            InitializationInfo.Initialization<T>(context);
        }

    }
    public class InitializationInfo
    {
        public static void Initialization<T>(T context)
        {

        }
    }
}
