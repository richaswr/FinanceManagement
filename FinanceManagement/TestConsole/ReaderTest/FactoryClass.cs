namespace TestConsole.ReaderTest
{
    public class FactoryClass
    {
        public static IActivity CreateInstance(Enumeration.ModuleName enumModuleName)
        {
            IActivity objActivity = null;

            switch (enumModuleName)
            {
                case Enumeration.ModuleName.ReportGenerator:
                    objActivity = new ReportGenerator();
                    break;
                case Enumeration.ModuleName.ReportAnalyser:
                    objActivity = new ReportAnalyser();
                    break;
                default:
                    break;
            }

            return objActivity;
        }
    }
}
