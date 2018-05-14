namespace FinanceManagement.DataAccess
{
    using System;
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
        public IDbConnection SetSqlConnection()
        {
            Connection = new SqlConnection(@"Data Source=Titan;Initial Catalog=Finance;Integrated Security=True");
            return Connection;
        }

        /// <summary>
        /// Defines the Connection as an OdbcConnection object.
        /// </summary>
        /// <param name="directoryPath"></param>
        public IDbConnection SetOdbcConnection(string directoryPath)
        {
            var builder = new OdbcConnectionStringBuilder {Driver = "{Microsoft Text Driver (*.txt; *.csv)}"};
            builder.Add("Dbq", directoryPath);
            builder.Add("Extensions", "asc,csv,tab,txt");
            builder.Add("Persist Security Info", "False");

            Connection = new OdbcConnection(builder.ConnectionString);
            return Connection;
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

            ApplyParameterValue(ref parameter, parameterValue);

            command.Parameters.Add(parameter);
        }

        /// <summary>
        /// Determines the value for a given parameter.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public IDataParameter ApplyParameterValue(ref IDbDataParameter parameter, object parameterValue)
        {
            if (parameter.DbType == DbType.String)
            {
                parameter.Value = string.IsNullOrEmpty(parameterValue.ToString()) ? DBNull.Value : parameterValue;
                return parameter;
            }

            parameter.Value = parameterValue;
            return parameter;
        }
    }
}
