
namespace Agenda.Domain.Core.Helpers
{
    public class SortThenHelper
    {
        public string FieldName { get; set; }
        public string FieldTypeThenBy { get; set; }

        public SortThenHelper(string fieldName, TypeThen typeThenBy)
        {
            FieldTypeThenBy = typeThenBy.ToString();
            FieldName = fieldName;
        }
    }
}
