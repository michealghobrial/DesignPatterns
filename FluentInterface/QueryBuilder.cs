using System;
using System.Collections.Generic;
using System.Text;

namespace FluentInterface
{
    public class QueryBuilder
    {
        private string _select;
        private string _from;
        private string _where;

        public QueryBuilder Select(string columns)
        {
            _select = $"SELECT {columns}";
            return this;
        }

        public QueryBuilder From(string table)
        {
            _from = $"FROM {table}";
            return this;
        }

        public QueryBuilder Where(string condition)
        {
            _where = $"WHERE {condition}";
            return this;
        }
        public string Build()
        {
            return $"{_select} {_from} {_where}";
        }
    }
}
