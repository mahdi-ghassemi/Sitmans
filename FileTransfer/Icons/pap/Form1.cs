using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace $safeprojectname$
{
    public partial class Form1 : Form
    {
        SqlConnection login = new SqlConnection("Data Source=SHIVA-PC;Initial Catalog=info;Integrated Security=True");
        SqlCommand command;
   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void login_btn_Click_1(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "Data Source=SHIVA-PC;Initial Catalog=info;Integrated Security=True";
                SqlConnection login = new SqlConnection(myconnection);
                SqlCommand command = new SqlCommand("select * from database.info where username='"
                    + this + username_txt.Text + "'and password='" + this + pass_txt.Text + "';", login);
                SqlDataReader reader;
                login.Open();
                reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("USERNAME AND PASSWORD IS CORRECT");
                }
                else if (count > 1)
                {
                    MessageBox.Show("ACCSSES DENIED");
                }
                else MessageBox.Show("USERNAME OR PASSWORD IS INCORRECT");
                login.Close();
            }
               
            
              

            catch (Exception exp)
            {
            }


        }
                




              


               



        }
    
}
