namespace TestConsole.ReaderTest
{
    public interface IActivity
    {
        void Process();
    }

    public class Enumeration
    {
        public enum ModuleName
        {
            ReportGenerator = 1,
            ReportAnalyser = 2
        }
    }

    public class ReportGenerator : IActivity
    {
        public void Process() { }
    }

    public class ReportAnalyser : IActivity
    {
        public void Process() { }
    }
}
