using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdudexApp
{
    public partial class Form2 : Form
    {
        public Form FormToShowOnClosing { get; set; }
        string host;
        string password;
        int port;
        string user;

        //---- database server----
        string db_server;
        string database;
        string db_UID;
        string db_pwd;
        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != FormToShowOnClosing)
            {
                FormToShowOnClosing.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormToShowOnClosing.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            host = Properties.Settings.Default.hostip;
            textBox1.Text = host;

            user = Properties.Settings.Default.user;
            textBox7.Text = user;

            password = Properties.Settings.Default.password;
            textBox6.Text = password;

            port = Properties.Settings.Default.sshport;
            textBox8.Text = port.ToString();

            GetConnectionStrings();
            
        }

        private void GetConnectionStrings()
        {
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["MySql"];
            if (settings != null)
            {
               
                string[] msg = settings.ConnectionString.Split(';');
                //server
                var s = msg[0].Split('=');
                db_server = s[1];
                
                // database name
                var db = msg[1].Split('=');
                database= db[1];
                
                // database user name
                var s1 = msg[2].Split('=');
                db_UID = s1[1];
                
                //DB user password
                var pas = msg[3].Split('=');
                db_pwd= pas[1];

                textBox2.Text = db_pwd;
                textBox3.Text = db_UID;
                textBox4.Text = database;
                textBox5.Text = db_server;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Properties.Settings.Default.hostip = textBox1.Text.Trim();
            }
            else
            {
                MessageBox.Show("Host Ip address required");
            }

            if (!string.IsNullOrWhiteSpace(textBox6.Text))
            {
                Properties.Settings.Default.password = textBox6.Text.Trim();
            }
            else
            {
                MessageBox.Show("User Password required");
            }

            if (!string.IsNullOrWhiteSpace(textBox7.Text))
            {
                Properties.Settings.Default.user = textBox7.Text.Trim();
            }
            else
            {
                MessageBox.Show("User name for host required");
            }

            if (!string.IsNullOrWhiteSpace(textBox8.Text))
            {
                Properties.Settings.Default.sshport =Convert.ToInt32(textBox8.Text);
            }
            else
            {
                MessageBox.Show("Host port required");
            }

            //if (!string.IsNullOrWhiteSpace(textBox1.Text))
            //{
            //    Properties.Settings.Default.hostip = textBox1.Text.Trim();
            //}
            //else
            //{
            //    MessageBox.Show("Host Ip address required");
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            db_pwd = "PASSWORD="+ textBox2.Text.Trim() +";";
            db_UID = "UID"+textBox3.Text.Trim() +";";
            database = "DATABASE" + textBox4.Text.Trim()+ ";";
            db_server = "SERVER" + textBox5.Text.Trim() +";";
            string constr = db_server + database + db_UID + db_pwd;

            //Configuration config = ConfigurationManager.OpenExeConfiguration("~/App.config");
            //config.ConnectionString["MySql"].ConnectionString.value = constr.ToString();
            //config.Save();
        }
    }
}
