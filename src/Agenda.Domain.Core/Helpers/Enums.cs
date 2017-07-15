using System.ComponentModel;

namespace Agenda.Domain.Core.Helpers
{
    public enum TypeOrder
    {
        [Description("OrderBy")]
        ASC,
        [Description("OrderByDescending")]
        DESC
    };

    public enum TypeThen
    {
        [Description("ThenBy")]
        ASC,
        [Description("ThenByDescending")]
        DESC
    };
}
