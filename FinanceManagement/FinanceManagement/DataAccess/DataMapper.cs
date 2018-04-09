namespace FinanceManagement.DataAccess
{
    using System.Collections.ObjectModel;
    using System.Data;

    public abstract class DataMapper<T>
    {
        protected abstract T Map(IDataRecord record);
        public Collection<T> MapAll(IDataReader reader)
        {
            var collection = new Collection<T>();

            while (reader.Read())
            {
                collection.Add(Map(reader));
            }

            return collection;
        }

        public T MapSingle(IDataReader reader)
        {
            reader.Read();
            return Map(reader);
        }
    }
}
