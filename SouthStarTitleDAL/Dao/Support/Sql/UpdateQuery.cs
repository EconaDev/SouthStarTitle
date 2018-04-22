using System.Text;
using SouthStarTitleDAL.Dao.Support.Data;
using SouthStarTitleCommon.Text;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public abstract class UpdateQuery : IUpdateQuery
    {
        // Fields
        protected string _table;
        protected ICriteria criteria;
        protected DbProviderType provider;
        protected StringBuilder sb;
        protected DbType type;

        // Methods
        internal UpdateQuery(DbType type, DbProviderType provider)
        {
            this._table = "";
            this.sb = new StringBuilder();
            this.criteria = null;
            this.type = DbType.SQLSERVER;
            this.provider = DbProviderType.SQLSERVER;
            this.type = type;
            this.provider = provider;
        }

        internal UpdateQuery(DbType type, DbProviderType provider, string tableName)
            : this(type, provider)
        {
            this.SetTable(tableName);
        }

        public void Add(string columnName)
        {
            this.sb.Append(string.Concat(new object[] { " ", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), " = ", QueryHelper.GetParameterName(columnName, this.provider), "," }));
        }

        public void Add(string columnName, object columnValue)
        {
            this.sb.Append(string.Concat(new object[] { " ", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), " = ", QueryHelper.DressUp(columnValue, this.type), "," }));
        }

        public void AddNull(string columnName)
        {
            this.sb.Append(string.Concat(new object[] { " ", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), " = NULL," }));
        }

        public ICriteria CreateCriteria()
        {
            return CriteriaFactory.CreateCriteria(this.type);
        }

        protected string GetColumns()
        {
            return StringUtil.RemoveFinalComma(this.sb.ToString());
        }

        protected string GetCriteria()
        {
            if (this.criteria == null)
            {
                return "";
            }
            return this.criteria.GetText();
        }

        public virtual string GetText()
        {
            return ("UPDATE " + this._table + " SET " + this.GetColumns() + this.GetCriteria());
        }

        public void SetCriteria(ICriteria c)
        {
            this.criteria = c;
        }

        public void SetTable(string tableName)
        {
            this._table = QueryHelper.GetPreDelimeter(this.type) + tableName + QueryHelper.GetPostDelimeter(this.type);
        }

        // Properties
        public ICriteria Criteria
        {
            get
            {
                return this.criteria;
            }
        }

        public DbProviderType DbProviderType
        {
            get
            {
                return this.provider;
            }
            set
            {
                this.provider = value;
            }
        }

        public string Statement
        {
            get
            {
                return this.GetText();
            }
        }
    }
}
