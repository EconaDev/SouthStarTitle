using System;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public class QueryFactory
    {
        // Methods
        public static IDeleteQuery CreateDeleteQuery(DbType db)
        {
            switch (db)
            {
                //case DbType.ACCESS:
                //    return new AccessDeleteQuery();

                case DbType.SQLSERVER:
                    return new SqlDeleteQuery();

                //case DbType.MYSQL:
                //    return new MySqlDeleteQuery();

                //case DbType.ORACLE:
                //    return new OracleDeleteQuery();
            }
            throw new NotImplementedException("DbType " + db + " not supported currently.");
        }

        public static IDeleteQuery CreateDeleteQuery(string db)
        {
            return CreateDeleteQuery(DbTypeConverter.Convert(db));
        }

        public static IDeleteQuery CreateDeleteQuery(DbType db, DbProviderType provider)
        {
            IDeleteQuery query = CreateDeleteQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static IDeleteQuery CreateDeleteQuery(string db, DbProviderType provider)
        {
            IDeleteQuery query = CreateDeleteQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static IInsertQuery CreateInsertQuery(DbType db)
        {
            switch (db)
            {
                //case DbType.ACCESS:
                //    return new AccessInsertQuery();

                case DbType.SQLSERVER:
                    return new SqlInsertQuery();

                //case DbType.MYSQL:
                //    return new MySqlInsertQuery();

                //case DbType.ORACLE:
                //    return new OracleInsertQuery();
            }
            throw new NotImplementedException("DbType " + db + " not supported currently.");
        }

        public static IInsertQuery CreateInsertQuery(string db)
        {
            return CreateInsertQuery(DbTypeConverter.Convert(db));
        }

        public static IInsertQuery CreateInsertQuery(DbType db, DbProviderType provider)
        {
            IInsertQuery query = CreateInsertQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static IInsertQuery CreateInsertQuery(string db, DbProviderType provider)
        {
            IInsertQuery query = CreateInsertQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static ISelectQuery CreateSelectQuery(DbType db)
        {
            switch (db)
            {
                //case DbType.ACCESS:
                //    return new AccessSelectQuery();

                case DbType.SQLSERVER:
                    return new SqlSelectQuery();

                //case DbType.MYSQL:
                //    return new MySqlSelectQuery();

                //case DbType.ORACLE:
                //    return new OracleSelectQuery();
            }
            throw new NotImplementedException("DbType " + db + " not supported currently.");
        }

        public static ISelectQuery CreateSelectQuery(string db)
        {
            return CreateSelectQuery(DbTypeConverter.Convert(db));
        }

        public static ISelectQuery CreateSelectQuery(DbType db, DbProviderType provider)
        {
            ISelectQuery query = CreateSelectQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static IUpdateQuery CreateUpdateQuery(DbType db)
        {
            switch (db)
            {
                //case DbType.ACCESS:
                //    return new AccessUpdateQuery();

                case DbType.SQLSERVER:
                    return new SqlUpdateQuery();

                //case DbType.MYSQL:
                //    return new MySqlUpdateQuery();

                //case DbType.ORACLE:
                //    return new OracleUpdateQuery();
            }
            throw new NotImplementedException("DbType " + db + " not supported currently.");
        }

        public static IUpdateQuery CreateUpdateQuery(string db)
        {
            return CreateUpdateQuery(DbTypeConverter.Convert(db));
        }

        public static IUpdateQuery CreateUpdateQuery(DbType db, DbProviderType provider)
        {
            IUpdateQuery query = CreateUpdateQuery(db);
            query.DbProviderType = provider;
            return query;
        }

        public static IUpdateQuery CreateUpdateQuery(string db, DbProviderType provider)
        {
            IUpdateQuery query = CreateUpdateQuery(db);
            query.DbProviderType = provider;
            return query;
        }
    }

}
