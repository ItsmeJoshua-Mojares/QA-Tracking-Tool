using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using QualityAssuranceTrackingToolV2.Class;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static QualityAssuranceTrackingToolV2.Class.Class_Database;

namespace QualityAssuranceTrackingToolV2
{

    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string log;
        string Role;
        private void button1_Click(object sender, EventArgs e)  
        {
            try
            {

                if (classdatabase.Login(usertb.Text, passtb.Text,  out Role))
                {
                  
                    if (Role == "Admin")
                    {
                        Class_Global.type = "Admin";
                    }

                    else if (Role == "User")
                    {

                        Class_Global.type = "User";
                    }

                    log = "Welcome: " + usertb.Text;
                    this.Hide();
                    HomePage2 f2 = new HomePage2(log);
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Not Testable by Unit Test Merong  UI interaction
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}

