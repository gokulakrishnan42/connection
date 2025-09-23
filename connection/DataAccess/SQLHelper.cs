using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;




namespace connection.DataAccess
{
    internal class SQLHelper
    {
        public int ExcuteQuery(String query, Dictionary<string, string> parameters)
        {
            int result =-1;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(InMemory.Connection))
                {
                    sqlConn.Open();
                    using (SqlCommand cmd =new SqlCommand(query, sqlConn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                        }
                        result = cmd.ExecuteNonQuery();

                    }
                    sqlConn.Close();
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("SQL Error:" + ex.Message);

            }
            finally
            { }
            return result;
        }


    }
}
