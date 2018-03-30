namespace FinanceManagement.DataAccess
{
    using System.Data;
    using System.Data.Odbc;
    using System.Data.SqlClient;
    using System.IO;

    //TODO: Consider extension methods for flexibility
    public class DataContext
    {
        /// <summary>
        /// The connection that will be used to execute a command against.
        /// </summary>
        public IDbConnection Connection { get; set; }

        /// <summary>
        /// Defines the Connection as a SqlConnection object.
        /// </summary>
        public void SetSqlConnection()
        {
            Connection = new SqlConnection(@"Data Source=Titan;Initial Catalog=Finance;Integrated Security=True");
        }

        /// <summary>
        /// Defines the Connection as an OdbcConnection object.
        /// </summary>
        /// <param name="directoryPath"></param>
        public void SetOdbcConnection(string directoryPath)
        {
            var builder = new OdbcConnectionStringBuilder {Driver = "{Microsoft Text Driver (*.txt; *.csv)}"};
            builder.Add("Dbq", directoryPath);
            builder.Add("Extensions", "asc,csv,tab,txt");
            builder.Add("Persist Security Info", "False");

            Connection = new OdbcConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Creates a SqlCommand with a provided stored procedure name.
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SqlCommand CreateSqlCommand(string commandText)
        {
            var command = (SqlCommand) Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            return command;
        }

        /// <summary>
        /// Creates an OdbcCommand to open a specific file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public OdbcCommand CreateOdbcCommand(string fileName)
        {
            var fileNameOnly = Path.GetFileName(fileName);
            var command = (OdbcCommand) Connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM [{fileNameOnly}]";
            return command;
        }

        /// <summary>
        /// Adds a parameter to the Command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterDirection"></param>
        public void AddParameter(IDbCommand command, DbType dbType, string parameterName, object parameterValue, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            var parameter = command.CreateParameter();
            parameter.DbType = dbType;
            parameter.ParameterName = parameterName;
            parameter.Direction = parameterDirection;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}
