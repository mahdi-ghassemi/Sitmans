using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class Form2 : Form
    {
        
        SqlConnection login = new SqlConnection("Data Source=SHIVA-PC;Initial Catalog=info;Integrated Security=True");
        SqlCommand command;
   
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            { 
                Command=new sqlcommand("insert into customer(id,name,family,tel,address,description)values('"+id_txt.Text+"','"+name_txt.Text+'",'"+family_txt.Text+"','"+tel_txt.Text"','"+add_txt.Text"','"+des_txt.Text+"',info);
                    Command.executenonquery();
                MessageBox.Show("ثبت شد");
                info.close();
                save_btn.Enabled=false;
                return_btn.Enabled=true;
            }
            catch(Exception ex)

            }
        
                   
                 
             
            
            
        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            return_btn.Enabled = false;
            save_btn.Enabled = true;
        }
    }}

