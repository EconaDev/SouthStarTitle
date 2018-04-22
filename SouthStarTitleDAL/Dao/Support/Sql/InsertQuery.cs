using System.Text;
using SouthStarTitleCommon.Text;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public abstract class InsertQuery : IInsertQuery
    {
        // Fields
        protected string _table;
        protected int cindex;
        protected string[] cnames;
        protected ICriteria criteria;
        protected string[] cvalues;
        protected DbProviderType provider;
        protected StringBuilder sbn;
        protected StringBuilder sbv;
        protected DbType type;

        // Methods
        internal InsertQuery(DbType type, DbProviderType provider)
        {
            this._table = "";
            this.sbn = new StringBuilder();
            this.sbv = new StringBuilder();
            this.cnames = new string[500];
            this.cvalues = new string[500];
            this.cindex = 0;
            this.criteria = null;
            this.type = DbType.SQLSERVER;
            this.provider = DbProviderType.SQLSERVER;
            this.type = type;
            this.provider = provider;
        }

        internal InsertQuery(DbType type, DbProviderType provider, string tableName)
            : this(type, provider)
        {
            this.SetTable(tableName);
        }

        public void Add(string columnName)
        {
            this.cnames[this.cindex] = columnName;
            this.cvalues[this.cindex] = QueryHelper.GetParameterName(columnName, this.provider);
            this.cindex++;
        }

        public void Add(string columnName, object columnValue)
        {
            this.cnames[this.cindex] = columnName;
            this.cvalues[this.cindex] = QueryHelper.DressUp(columnValue, this.type);
            this.cindex++;
        }

        public void AddNull(string columnName)
        {
            this.cnames[this.cindex] = columnName;
            this.cvalues[this.cindex] = "NULL";
            this.cindex++;
        }

        public ICriteria CreateCriteria()
        {
            return CriteriaFactory.CreateCriteria(this.type);
        }

        protected string GetColumnNames()
        {
            this.sbn.Remove(0, this.sbn.Length);
            for (int i = 0; i <= this.cindex; i++)
            {
                if ((this.cnames[i] != null) && (this.cnames[i].Length > 0))
                {
                    this.sbn.Append(string.Concat(new object[] { QueryHelper.GetPreDelimeter(this.type), this.cnames[i], QueryHelper.GetPostDelimeter(this.type), ", " }));
                }
            }
            return StringUtil.RemoveFinalComma(this.sbn.ToString());
        }

        protected string GetColumnValues()
        {
            this.sbv.Remove(0, this.sbv.Length);
            for (int i = 0; i <= this.cindex; i++)
            {
                if ((this.cnames[i] != null) && (this.cnames[i].Length > 0))
                {
                    this.sbv.Append(this.cvalues[i] + ", ");
                }
            }
            return StringUtil.RemoveFinalComma(this.sbv.ToString());
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
            return ("INSERT INTO " + this._table + " ( " + this.GetColumnNames() + " ) VALUES ( " + this.GetColumnValues() + " ) " + this.GetCriteria());
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
