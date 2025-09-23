using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Windows;
namespace connection
{
    /// <summary>
    /// Interaction logic for ConnectionScreen.xaml
    /// </summary>
    public partial class ConnectionScreen : Window
    {
        public ConnectionScreen()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    SqlConnection sqlcon = new SqlConnection();
                    if (CB.IsChecked == true)
                    {
                        sqlcon.ConnectionString = $"Data Source={txtserver.Text};Initial Catalog={txtDatabase.Text};integrated Security=true; Encrypt=false" ;
                    }
                    else
                    {

                        sqlcon.ConnectionString = $"Data Source={txtserver.Text};Initial Catalog={txtDatabase.Text};User id={txtusername.Text};Password={txtPassword.Password}; Encrypt=false";
                    }
                    sqlcon.Open();
                    MessageBox.Show("Connection Successful");
                    QueryWindow queryWindow = new QueryWindow(sqlcon.ConnectionString);
                    queryWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed:" + ex.Message);
                }
            }

        }
    }
}
