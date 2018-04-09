namespace TestConsole
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;

    public static class Reader
    {
        public static Collection<string> GetFromStream(StreamReader streamReader)
        {
            var collection = new Collection<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var cols = line.Split(new[] {','}, StringSplitOptions.None);
                collection.Add(cols[0]);
            }

            return collection;
        }
    }
}
