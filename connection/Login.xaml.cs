using Microsoft.Data.SqlClient;
using System.Windows;
using Microsoft.Data.Sql;

namespace connection
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();


        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection sql = new SqlConnection())
            {
                try
                {
                    sql.ConnectionString = @"Data Source=DESKTOP-O42HGKC\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        cmd.Connection = sql;
                        //cmd.CommandText = $"INSERT INTO USERS VALUES('{txtemail.Text}','{txtpassword.Password}')";
                        //cmd.CommandText = $"SELECT COUNT(*) FROM USERS WHERE Email='{txtemail.Text}' and password='{txtpassword.Password}'";
                        cmd.CommandText = $"SELECT COUNT(*) FROM USERS WHERE Email=@email and Password=@password";
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Password);
                        int count = (int)cmd.ExecuteScalar();
                        sql.Close();

                        bool val = count > 0 ? true : false;

                        if (val == false)
                        {
                            MessageBox.Show("invalid credentials");

                        }
                        else
                        {
                            Register reg = new Register();
                            reg.Show();
                            this.Close();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Error" + ex.Message);
                }
                finally
                {
                    sql.Close();
                }

            } 
           









            //try
            //{
            //    bool isValid = isValidEmail(txtemail.Text);
            //    if (isValid == true)
            //    {
            //        MessageBox.Show("Email already exists");
            //    }
            //    else
            //    {


            //        SqlConnection sql = new SqlConnection();
            //        sql.ConnectionString = @"Data Source=DESKTOP-O42HGKC\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";
            //        sql.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = sql;
            //        //cmd.CommandText = $"INSERT INTO USERS VALUES('{txtemail.Text}','{txtpassword.Password}')";
            //        cmd.CommandText = $"SELECT COUNT(*) FROM USERS WHERE Email='{txtemail.Text}' and password='{txtpassword.Password}'";
            //        int count = (int)cmd.ExecuteScalar();

            //        bool val = count > 0 ? true : false;

            //        if (val == false)
            //        {
            //            MessageBox.Show("invalid credentials");

            //        }
            //        else
            //        {
            //            Home home = new Home();
            //            home.Show(); 
            //            this.Close();
            //        }

            //        //int val = cmd.ExecuteNonQuery();
            //        //if (val > 0)
            //        //{
            //        //    MessageBox.Show("login succesful");
            //        //}
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("SQL Error: " + ex.Message);


            //}
            //finally
            //{

            //}



        }
        private bool isValidEmail(string email)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Data Source=DESKTOP-O42HGKC\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandText = $"SELECT COUNT(*) FROM USERS WHERE Email='{email}'";
            int count = (int)cmd.ExecuteScalar();

            bool val = count > 0 ? false : true;
            return val;

            //if(count > 0)
            //{
            //    val = false;
            //}
            //else
            //{
            //    val = true;
            //}




        }



        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            
        }  
    }
}
