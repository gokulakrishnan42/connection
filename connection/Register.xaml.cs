using connection.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using connection.BL;
namespace connection
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
             string Connection = "Data Source=DESKTOP-O42HGKC\\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";


        SqlConnection sql = new SqlConnection();
            sql.ConnectionString = Connection;
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandText = "SELECT CID,CNAME FROM COURSE";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Course");

            comboCourse.DisplayMemberPath = "CNAME";   
            comboCourse.SelectedValuePath = "CID";
            comboCourse.ItemsSource = ds.Tables["course"].DefaultView;
            sql.Close();





        }



        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            connection.Model.Student student = new connection.Model.Student();
            StdRegister or =new StdRegister();
            student.Sname = txtname.Text;
            student.Email= txtemail.Text;
            student.Phone=Convert.ToInt32(txtphone.Text);
            student.Dob = DateDOB.SelectedDate?.ToString("yyyy-MM-dd");
            student.cid = Convert.ToInt16(comboCourse.SelectedValue);
            student.Address = txtAddress.Text;
            int result = or.RegisterCourse(student);













            //try
            //{



            //    SqlConnection sql = new SqlConnection();
            //    sql.ConnectionString = @"Data Source=DESKTOP-O42HGKC\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";
            //    sql.Open();
            //    SqlCommand cmd = new SqlCommand("INSERT INTO StudCourse VALUES(@sname,@email,@phone,@dob,@cid,@Address)", sql);
            //    cmd.Parameters.AddWithValue("@sname", txtname.Text);
            //    cmd.Parameters.AddWithValue("@email", txtemail.Text);
            //    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            //    cmd.Parameters.AddWithValue("@dob", DateDOB.SelectedDate);
            //    cmd.Parameters.AddWithValue("@cid", comboCourse.SelectedValue);
            //    cmd.Parameters.AddWithValue("@address", txtAddress.Text);

            //    int val = cmd.ExecuteNonQuery();
            //    if (val > 0)
            //    {
            //        MessageBox.Show("Student Resgistration Successfully");
            //    }



            //}


            //catch (SqlException ex)
            //{
            //    MessageBox.Show("SQL Error: " + ex.Message);


            //}
            //finally
            //{ }
        }

        //private int RegisterCourse(Student student)
        //{
        //    throw new NotImplementedException();
        //}
    }
}



//"INSERT INTO StudCourse (SNAME, EMAIL, PHONE, DOB, CID, ADDRESS) " +
//    "VALUES (@sname, @email, @phone, @dob, @cid, @address)", sql);




























