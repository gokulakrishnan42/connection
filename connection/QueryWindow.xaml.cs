using Microsoft.Data.SqlClient;
using System.Windows;
namespace connection
{
    /// <summary>
    /// Interaction logic for QueryWindow.xaml
    /// </summary>
    public partial class QueryWindow : Window
    {
        private string conn;
        public QueryWindow(string connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void btnrun_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(txtquery.Text,sqlConnection);

            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = txtquery.Text;
            
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }
    }
}
