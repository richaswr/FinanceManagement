namespace FinanceManagement
{
    using System.Text.RegularExpressions;

    public static class ExtensionMethods
    {
        public static string RemoveNonNumeric(this string str)
        {
            var regEx = new Regex(@"[^\d]");
            return regEx.Replace(str, string.Empty);
        }
    }
}
