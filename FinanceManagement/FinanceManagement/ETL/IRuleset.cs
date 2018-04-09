using System;
using System.Collections.ObjectModel;

namespace FinanceManagement.ETL
{
    public interface IRuleset
    {
        Collection<Func<bool>> Rules { get; }

        Ruleset EndsWith(string value);
        Ruleset HasEmptyColumn(string delimiter, int columnIndex);
        Ruleset StartsWith(string value);
    }
}