namespace FinanceManagement.Transactions.Validation
{
    public class StartsWith : IValidationRule
    {
        private string _value;
        public StartsWith(string value)
        {
            _value = value;
        }

        public bool BreaksValidation(string row)
        {
            return row.StartsWith(_value);
        }
    }
}
