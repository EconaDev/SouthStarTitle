using System;
using System.Text;
using System.Collections;
using SouthStarTitleCommon.Text;
using SouthStarTitleDAL.Dao.Support.Data;

namespace SouthStarTitleDAL.Dao.Support.Sql
{
    public abstract class SelectQuery : ISelectQuery, ISqlQuery, IQuery
    {
        // Fields
        protected string _join;
        protected string _table;
        protected ICriteria criteria;
        protected Queue group;
        protected int maxRecords;
        protected OrderBy ob;
        protected Queue order;
        private bool orderSet;
        protected DbProviderType provider;
        protected StringBuilder sb;
        protected DbType type;

        // Methods
        internal SelectQuery(DbType type, DbProviderType provider)
        {
            this._table = "";
            this.sb = new StringBuilder();
            this.order = new Queue();
            this.group = new Queue();
            this.ob = OrderBy.ASCENDING;
            this.criteria = null;
            this.type = DbType.SQLSERVER;
            this.provider = DbProviderType.SQLSERVER;
            this.maxRecords = 0;
            this._join = "";
            this.orderSet = false;
            this.type = type;
            this.provider = provider;
        }

        internal SelectQuery(DbType type, DbProviderType provider, string tableName)
            : this(type, provider)
        {
            this.SetTable(tableName);
        }

        public void Add(string columnName)
        {
            this.sb.Append(" ");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(columnName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(",");
        }

        public void Add(string tableName, string columnName)
        {
            this.sb.Append(" ");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(tableName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(".");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(columnName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(",");
        }

        public void AddAll()
        {
            this.sb.Append(" * ");
        }

        public void AddColumnAlias(string columnName, string alias)
        {
            this.sb.Append(" ");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(columnName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(" AS ");
            this.sb.Append(alias);
            this.sb.Append(",");
        }

        public void AddColumnAlias(string tableName, string columnName, string alias)
        {
            this.sb.Append(" ");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(tableName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(".");
            this.sb.Append(QueryHelper.GetPreDelimeter(this.type));
            this.sb.Append(columnName);
            this.sb.Append(QueryHelper.GetPostDelimeter(this.type));
            this.sb.Append(" AS ");
            this.sb.Append(alias);
            this.sb.Append(",");
        }

        public virtual void AddCount(string columnName)
        {
            this.sb.Append(string.Concat(new object[] { " COUNT(", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), ") " }));
        }

        public virtual void AddCountAll()
        {
            this.sb.Append(" COUNT(*) ");
        }

        public void AddGroupBy(params string[] columns)
        {
            foreach (string str in columns)
            {
                this.AddGroupBy(str);
            }
        }

        public void AddGroupBy(string columnName)
        {
            this.group.Enqueue(QueryHelper.GetPreDelimeter(this.type) + columnName + QueryHelper.GetPostDelimeter(this.type));
        }

        public virtual void AddJoin(string secondTable, string firstTableColumn, string secondTableColumn, JoinType type)
        {
            this._join = string.Format(" {0} {1} ON {2}.{3} = {4}.{5} ", new object[] { this.GetJoinType(type), QueryHelper.GetPreDelimeter(this.type) + secondTable + QueryHelper.GetPostDelimeter(this.type), this._table, QueryHelper.GetPreDelimeter(this.type) + firstTableColumn + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + secondTable + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + secondTableColumn + QueryHelper.GetPostDelimeter(this.type) });
        }

        public virtual void AddJoin(string secondTable, string firstTableColumn, string secondTableColumn, string thirdTable, string thirdTableColumn, string fourthTable, string fourthTableColumn, JoinType type)
        {
            this._join = string.Format(" {0} {1} ON {2}.{3} = {4}.{5} {6} {7} ON {8}.{9} = {10}.{11} ", new object[] { this.GetJoinType(type), QueryHelper.GetPreDelimeter(this.type) + secondTable + QueryHelper.GetPostDelimeter(this.type), this._table, QueryHelper.GetPreDelimeter(this.type) + firstTableColumn + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + secondTable + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + secondTableColumn + QueryHelper.GetPostDelimeter(this.type), this.GetJoinType(type), QueryHelper.GetPreDelimeter(this.type) + fourthTable + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + thirdTable + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + thirdTableColumn + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + fourthTable + QueryHelper.GetPostDelimeter(this.type), QueryHelper.GetPreDelimeter(this.type) + fourthTableColumn + QueryHelper.GetPostDelimeter(this.type) });
        }

        public void AddOrderBy(string columnName)
        {
            this.order.Enqueue(QueryHelper.GetPreDelimeter(this.type) + columnName + QueryHelper.GetPostDelimeter(this.type));
        }

        public void AddOrderBy(string tableName, params string[] columns)
        {
            foreach (string str in columns)
            {
                this.AddOrderBy(tableName, str);
            }
        }

        public void AddOrderBy(string columnName, OrderBy orderBy)
        {
            this.order.Enqueue(string.Concat(new object[] { QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), " ", this.TranslateOrderBy(orderBy) }));
            this.orderSet = true;
        }

        public void AddOrderBy(string tableName, string columnName)
        {
            this.order.Enqueue(string.Concat(new object[] { QueryHelper.GetPreDelimeter(this.type), tableName, QueryHelper.GetPostDelimeter(this.type), ".", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type) }));
        }

        public void AddOrderBy(string tableName, string columnName, OrderBy orderBy)
        {
            this.order.Enqueue(string.Concat(new object[] { QueryHelper.GetPreDelimeter(this.type), tableName, QueryHelper.GetPostDelimeter(this.type), ".", QueryHelper.GetPreDelimeter(this.type), columnName, QueryHelper.GetPostDelimeter(this.type), " ", this.TranslateOrderBy(orderBy) }));
            this.orderSet = true;
        }

        public void AddOrderByColumns(params string[] columns)
        {
            foreach (string str in columns)
            {
                this.AddOrderBy(str);
            }
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
            if (!((this.criteria != null) && this.criteria.Initialized))
            {
                return "";
            }
            return this.criteria.GetText();
        }

        protected virtual string GetGroupBy()
        {
            StringBuilder builder = new StringBuilder();
            if (this.group.Count > 0)
            {
                builder.Append(" GROUP BY ");
                IEnumerator enumerator = this.group.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    builder.Append(enumerator.Current + ", ");
                }
                return StringUtil.RemoveFinalComma(builder.ToString());
            }
            return "";
        }

        protected string GetJoinType(JoinType type)
        {
            switch (type)
            {
                case JoinType.LEFT:
                    return "LEFT OUTER JOIN";

                case JoinType.RIGHT:
                    return "RIGHT OUTER JOIN";

                case JoinType.INNER:
                    return "INNER JOIN";

                case JoinType.OUTER:
                    return "FULL OUTER JOIN";
            }
            throw new Exception("JoinType " + type + " not supported.");
        }

        protected virtual string GetLimit()
        {
            if (this.maxRecords > 0)
            {
                return (" TOP " + this.maxRecords);
            }
            return "";
        }

        protected virtual string GetOrderBy()
        {
            StringBuilder builder = new StringBuilder();
            if (this.order.Count > 0)
            {
                builder.Append(" ORDER BY ");
                IEnumerator enumerator = this.order.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    builder.Append(enumerator.Current + ", ");
                }
                return (StringUtil.RemoveFinalComma(builder.ToString()) + this.TranslateOrderBy());
            }
            return "";
        }

        public virtual string GetText()
        {
            return ("SELECT " + this.GetLimit() + this.GetColumns() + " FROM " + this._table + this._join + this.GetCriteria() + this.GetGroupBy() + this.GetOrderBy());
        }

        public void SetCriteria(ICriteria c)
        {
            this.criteria = c;
        }

        public void SetLimit(int maxRecords)
        {
            this.maxRecords = maxRecords;
        }

        public void SetTable(string tableName)
        {
            this._table = QueryHelper.GetPreDelimeter(this.type) + tableName + QueryHelper.GetPostDelimeter(this.type);
        }

        protected virtual string TranslateOrderBy()
        {
            if (!this.orderSet)
            {
                return this.TranslateOrderBy(this.ob);
            }
            return string.Empty;
        }

        protected virtual string TranslateOrderBy(OrderBy orderBy)
        {
            if (orderBy == OrderBy.DESCENDING)
            {
                return " DESC ";
            }
            return " ASC ";
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

        public OrderBy OrderBy
        {
            get
            {
                return this.ob;
            }
            set
            {
                this.ob = value;
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
