using System.Collections.Generic;

namespace Agenda.Domain.Core.Helpers
{
    public class SortHelper
    {
        private SortOrderHelper FieldOrder { get; set; }
        private IList<SortThenHelper> FieldsThen = new List<SortThenHelper>();

        public SortHelper(string fieldName, TypeOrder typeOrderBy)
        {
            FieldOrder = new SortOrderHelper(fieldName, typeOrderBy);
        }

        public void AddThenBy(string fieldName, TypeThen typeThenBy)
        {
            FieldsThen.Add(new SortThenHelper(fieldName, typeThenBy));
        }

        public SortOrderHelper GetFieldOrder()
        {
            return FieldOrder;
        }

        public IEnumerable<SortThenHelper> GetFieldsThen()
        {
            return FieldsThen;
        }
    }
}
