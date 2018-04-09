namespace TestConsole.ReaderTest
{
    using System.Resources;

    public class FactoryClassGeneric
    {
        public static IActivity CreateInstance(Enumeration.ModuleName enumModuleName)
        {
            IActivity objActivity = null;

            switch (enumModuleName)
            {
                case Enumeration.ModuleName.ReportGenerator:
                    objActivity = FactoryPatternGeneric<IActivity, ReportGenerator>.CreateInstance();
                    break;
                case Enumeration.ModuleName.ReportAnalyser:
                    objActivity = FactoryPatternGeneric<IActivity, ReportAnalyser>.CreateInstance();
                    break;
                default:
                    break;
            }

            return objActivity;
        }
    }
}
