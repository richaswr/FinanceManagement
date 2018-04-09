namespace FinanceManagement.ETL
{
    using System;
    using System.Collections.ObjectModel;
    using ETL;

    public class Ruleset : IRuleset
    {
        private Collection<Func<bool>> _rules;
        private string _data;
        private int _rowIndex;
        public Collection<Func<bool>> Rules => _rules;

        public Ruleset(string data, int rowIndex)
        {
            _data = data;
            _rowIndex = rowIndex;
            _rules = new Collection<Func<bool>>();
        }

        public Ruleset StartsWith(string value)
        {
            _rules.Add(() => _data.StartsWith(value));
            return this;
        }

        public Ruleset EndsWith(string value)
        {
            _rules.Add(() => _data.EndsWith(value));
            return this;
        }

        public Ruleset HasEmptyColumn(string delimiter, int columnIndex)
        {
            _rules.Add(() =>
            {
                var cols = _data.Split(new[] { delimiter }, StringSplitOptions.None);
                return string.IsNullOrEmpty(cols[columnIndex]);
            });

            return this;
        }

        public Ruleset IgnoreRowNumber(int rowIndex)
        {
            _rules.Add(() => _rowIndex == rowIndex);
            return this;
        }

        public Ruleset IgnoreHeaderRow()
        {
            IgnoreRowNumber(1);
            return this;
        }

    }
}
