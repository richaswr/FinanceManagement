namespace FinanceManagement.Transactions.Validation
{
    //TODO expand this to use fluent interface perhaps?
    public interface IValidationRule
    {
        bool BreaksValidation(string row);
    }
}
