
namespace Agenda.Domain.Core.Helpers
{
    public class SortOrderHelper
    {
        public string FieldName { get; set; }
        public string FieldTypeOrderBy { get; set; }

        public SortOrderHelper(string fieldName, TypeOrder typeOrderBy)
        {
            FieldTypeOrderBy = typeOrderBy.ToString();
            FieldName = fieldName;
        }
    }
}
