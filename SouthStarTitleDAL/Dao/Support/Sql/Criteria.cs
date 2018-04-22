using System.Text;
using System.Collections;
using SouthStarTitleCommon.Text;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public abstract class Criteria : ICriteria
    {
        // Fields
        protected bool initialized;
        protected DbProviderType provider;
        protected StringBuilder sb;
        protected DbType type;

        // Methods
        public Criteria(DbType type, DbProviderType provider)
        {
            sb = new StringBuilder();
            type = DbType.SQLSERVER;
            provider = DbProviderType.SQLSERVER;
            initialized = false;
            type = type;
            provider = provider;
        }

        public Criteria(DbType type, DbProviderType provider, string sql)
            : this(type, provider)
        {
            sql = sql.Replace("WHERE", "");
            AddSql(sql);
        }

        public void AddAnd()
        {
            if (initialized)
            {
                AddCriteriaSeparator(CriteriaType.AND);
            }
        }

        public virtual void AddAndCriteria(ICriteria c)
        {
            if (c.Initialized)
            {
                AddAnd();
                sb.Append("(");
                sb.Append(c.GetText().Replace("WHERE", "").Trim());
                sb.Append(") ");
                initialized = true;
            }
        }

        public virtual void AddBetween(string columnName, object value1, object value2)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" BETWEEN ");
            sb.Append(QueryHelper.DressUp(value1, type));
            sb.Append(" AND ");
            sb.Append(QueryHelper.DressUp(value2, type));
            sb.Append(" ");
            initialized = true;
        }

        protected void AddCriteriaSeparator(CriteriaType ct)
        {
            if (ct == CriteriaType.AND)
            {
                sb.Append(" AND ");
            }
            else
            {
                sb.Append(" OR ");
            }
        }

        public void AddEqualTo(string columnName)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" = ");
            sb.Append(QueryHelper.GetParameterName(columnName, DbProviderType));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddEqualTo(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" = ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddEqualTo(string tableName, string columnName)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(tableName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(".");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" = ");
            sb.Append(QueryHelper.GetParameterName(columnName, DbProviderType));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddEqualTo(string tableName, string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(tableName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(".");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" = ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public void AddEqualToOptimistic(string columnName)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" = ");
            if (DbProviderType != DbProviderType.OLEDB)
            {
                sb.Append(QueryHelper.GetParameterName(columnName + "1", DbProviderType));
            }
            else
            {
                sb.Append(QueryHelper.GetParameterName(columnName, DbProviderType));
            }
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddExists(ISqlQuery subSqlQuery)
        {
            sb.Append(" EXISTS (" + subSqlQuery.Statement + ") ");
            initialized = true;
        }

        public virtual void AddGreaterThan(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" > ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddGreaterThanOrEqualTo(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" >= ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddIn(string columnName, ISqlQuery subSqlQuery)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" IN (");
            sb.Append(subSqlQuery.GetText());
            sb.Append(") ");
            initialized = true;
        }

        public virtual void AddIn(string columnName, ICollection values)
        {
            var builder = new StringBuilder();
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" IN (");
            IEnumerator enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                builder.Append(QueryHelper.DressUp(enumerator.Current, type) + ", ");
            }
            sb.Append(StringUtil.RemoveFinalComma(builder.ToString()));
            sb.Append(") ");
            initialized = true;
        }

        public virtual void AddIsNull(string columnName)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" IS NULL ");
            initialized = true;
        }

        public virtual void AddIsNullOrEqualTo(string columnName)
        {
            sb.Append(" (");
            AddIsNull(columnName);
            AddOr();
            AddEqualToOptimistic(columnName);
            sb.Append(" )");
        }

        public virtual void AddLessThan(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" < ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddLessThanOrEqualTo(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" <= ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddLike(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" LIKE ");
            sb.Append(QueryHelper.DressUpContains(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddLike(string tableName, string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(tableName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(".");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" LIKE ");
            sb.Append(QueryHelper.DressUpContains(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddNotBetween(string columnName, object value1, object value2)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" NOT BETWEEN ");
            sb.Append(QueryHelper.DressUp(value1, type));
            sb.Append(" AND ");
            sb.Append(QueryHelper.DressUp(value2, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddNotEqualTo(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" <> ");
            sb.Append(QueryHelper.DressUp(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddNotExists(ISqlQuery subSqlQuery)
        {
            sb.Append(" NOT EXISTS (" + subSqlQuery.GetText() + ") ");
            initialized = true;
        }

        public virtual void AddNotIn(string columnName, ISqlQuery subSqlQuery)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" NOT IN (" + subSqlQuery.GetText() + ") ");
            initialized = true;
        }

        public virtual void AddNotIn(string columnName, ICollection values)
        {
            var builder = new StringBuilder();
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" NOT IN (");
            IEnumerator enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                builder.Append(QueryHelper.DressUp(enumerator.Current, type) + ", ");
            }
            sb.Append(StringUtil.RemoveFinalComma(builder.ToString()));
            sb.Append(")");
            initialized = true;
        }

        public virtual void AddNotLike(string columnName, object columnValue)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" NOT LIKE ");
            sb.Append(QueryHelper.DressUpContains(columnValue, type));
            sb.Append(" ");
            initialized = true;
        }

        public virtual void AddNotNull(string columnName)
        {
            sb.Append(" ");
            sb.Append(QueryHelper.GetPreDelimeter(type));
            sb.Append(columnName);
            sb.Append(QueryHelper.GetPostDelimeter(type));
            sb.Append(" IS NOT NULL ");
            initialized = true;
        }

        public void AddOr()
        {
            if (initialized)
            {
                AddCriteriaSeparator(CriteriaType.OR);
            }
        }

        public void AddOrCriteria(ICriteria c)
        {
            if (c.Initialized)
            {
                AddOr();
                sb.Append("(" + c.GetText().Replace("WHERE", "").Trim() + ") ");
                initialized = true;
            }
        }

        public virtual void AddSql(string sql)
        {
            sb.Append(" ");
            sb.Append(sql);
            sb.Append(" ");
            initialized = true;
        }

        public virtual string GetText()
        {
            if (initialized)
            {
                return (" WHERE " + sb);
            }
            return "";
        }

        // Properties
        public DbProviderType DbProviderType
        {
            get
            {
                return provider;
            }
            set
            {
                provider = value;
            }
        }

        public bool Initialized
        {
            get
            {
                return initialized;
            }
        }

        public string Statement
        {
            get
            {
                return GetText();
            }
        }
    }
}
