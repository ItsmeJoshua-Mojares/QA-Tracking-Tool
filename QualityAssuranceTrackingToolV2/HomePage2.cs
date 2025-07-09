using QualityAssuranceTrackingToolV2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;

namespace QualityAssuranceTrackingToolV2
{
    public partial class HomePage2 : Form
    {
        
        public HomePage2(string log)
        {
            InitializeComponent();
            welcomelbl.Text = log; //Para sa welcome label
        }
        
        private void logoutlbl_Click(object sender, EventArgs e)
        {
            //Babalik sa form1 which is yung login form
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }
        
        private void rmabtn_Click(object sender, EventArgs e)
        {
            //pupunta sa rmaregistration
            rmaregistration rmaregistration = new rmaregistration();
            rmaregistration.Show();
            this.Hide();
        }
        
        private void addbtn_Click(object sender, EventArgs e)
        {
            //pupunta sa add admin and user
            Add_user_addmin add = new Add_user_addmin();
            add.Show();
            this.Hide();
        }
        
        private void pupolateGridRMA()
        {
            try
            {
                // Retrieve the data from the TableRMA table
                DataTable dt = classdatabase.SelectADD();

                // Bind the data to the DataGridView control
                dgvs.DataSource = dt;

                // Set the image layout mode for the picture box column
                if (dgvs.Columns[11].GetType() == typeof(DataGridViewImageColumn))
                {
                    DataGridViewImageColumn pic1 = (DataGridViewImageColumn)dgvs.Columns[11];
                    pic1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void pupolateGridDVT()
        {
            try
            {
                // Retrieve the data from the TableRMA table
                DataTable dt = classdatabase.SelectDVT();

                // Bind the data to the DataGridView control
                dgvs.DataSource = dt;

                // Set the image layout mode for the picture box column
                if (dgvs.Columns[12].GetType() == typeof(DataGridViewImageColumn))
                {
                    DataGridViewImageColumn pic1 = (DataGridViewImageColumn)dgvs.Columns[12];
                    pic1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TextboxFilter()
        {
            try
            {
                // Check if both checkboxes are checked
                if (rmacb.Checked && dvtcb.Checked)
                {
                    // Retrieve the data from both TableRMA and TableDVT1 tables based on the search text
                    DataTable dtRMA = classdatabase.SearchADD(searchtb.Text);
                    DataTable dtDVT = classdatabase.SearchDVT(searchtb.Text);

                    // Combine the data from both tables
                    dtRMA.Merge(dtDVT);

                    // Bind the combined data to the DataGridView control
                    dgvs.DataSource = dtRMA;

                    // Set the image layout mode for the picture box column
                    if (dgvs.Columns[11].GetType() == typeof(DataGridViewImageColumn))
                    {
                        DataGridViewImageColumn pic1 = (DataGridViewImageColumn)dgvs.Columns[11];
                        pic1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }
                else if (rmacb.Checked) 
                {
                    // Retrieve the data from the TableRMA table based on the search text
                    DataTable dt = classdatabase.SearchADD(searchtb.Text);

                    // Bind the data to the DataGridView control
                    dgvs.DataSource = dt;

                    // Set the image layout mode for the picture box column
                    if (dgvs.Columns[11].GetType() == typeof(DataGridViewImageColumn))
                    {
                        DataGridViewImageColumn pic1 = (DataGridViewImageColumn)dgvs.Columns[11];
                        pic1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }
                else if (dvtcb.Checked)
                {
                    // Retrieve the data from the TableDVT1 table based on the search text
                    DataTable dt = classdatabase.SearchDVT(searchtb.Text);

                    // Bind the data to the DataGridView control
                    dgvs.DataSource = dt;

                    // Set the image layout mode for the picture box column
                    if (dgvs.Columns[11].GetType() == typeof(DataGridViewImageColumn))
                    {
                        DataGridViewImageColumn pic1 = (DataGridViewImageColumn)dgvs.Columns[11]; 
                        pic1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        
                    }
                }
                else
                {
                    // 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void rmacb_CheckedChanged(object sender, EventArgs e)
        {
            if (rmacb.Checked)
            {
                pupolateGridRMA();
            }
            else if (dvtcb.Checked)
            {
                pupolateGridDVT();
            }
            else if(rmacb.Checked && dvtcb.Checked)
            {
                pupolateGridDVT();
                pupolateGridRMA();
            }
            else
            {

            }
        }
        
        private void searchtb_TextChanged(object sender, EventArgs e)
        {
            TextboxFilter();
        }
        
        private void dvtbtn_Click(object sender, EventArgs e)
        {
            dvtregistration dvtregistration = new dvtregistration();
            dvtregistration.Show();
            this.Close();
        }
        
        private void dvtcb_CheckedChanged(object sender, EventArgs e)
        {
            if (rmacb.Checked)
            {
                pupolateGridRMA();
            }
            else if (dvtcb.Checked)
            {
                pupolateGridDVT();
            }
            else if (rmacb.Checked && dvtcb.Checked)
            {
                pupolateGridDVT();
                pupolateGridRMA();
            }
            else
            {

            }
        }
        
        private void HomePage2_Load(object sender, EventArgs e)
        {
            registrationpanel.Visible = false; 
            registrationpanel.Visible = true;
            if (Class_Global.type == "ADMIN")
            {
                // If the user is an Admin, show the registrationPanel
                registrationpanel.Visible = true;
            }
            else if (Class_Global.type == "USER")
            {
                // If the user is not an Admin, hide the registrationPanel
                registrationpanel.Visible = false;
            }
        }
        
        /*
               private void panel2_Paint(object sender, PaintEventArgs e)
               {

                   // Assuming you have an instance of Class_Database called 'classdatabase'
                   Class_Database classdatabase = new Class_Database();
                   Chart customerChart = classdatabase.GenerateCustomerChart();
                   Chart rmaPieChart = classdatabase.GenerateRMAPieChart();
                   Chart dvtPieChart = classdatabase.GenerateDVTPieChart();

                   // Add the customer chart to the rdcustomerchart panel
                   rdcustomerchart.Controls.Add(customerChart);
                   customerChart.Dock = DockStyle.Fill;

                   DataTable rmaData = classdatabase.SelectADD();
                   DataTable dvtData = classdatabase.SelectDVT();

                   // Count customers for RMA
                   int rmaCustomerCount = rmaData.Rows.Count;

                   // Count customers for DVT
                   int dvtCustomerCount = dvtData.Rows.Count;

                   // Count occurrences of "OK" status for RMA
                   int rmaOkCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");

                   // Count occurrences of "NOT OK" status for RMA
                   int rmaNotOkCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");

                   // Count occurrences of "ON GOING" status for RMA
                   int rmaOngoingCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

                   // Count occurrences of "OK" status for DVT
                   int dvtOkCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");

                   // Count occurrences of "NOT OK" status for DVT
                   int dvtNotOkCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");

                   // Count occurrences of "ON GOING" status for DVT
                   int dvtOngoingCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

                   // Update labels
                   rmalabel.Text = $"RMA: {rmaCustomerCount}";
                   dvtlabel.Text = $"DVVT: {dvtCustomerCount}";
                   rmalabelok.Text = $"RMA: {rmaOkCount}";
                   rmalabelnotok.Text = $"RMA: {rmaNotOkCount}";
                   rmalabelongoing.Text = $"RMA: {rmaOngoingCount}";

                   dvtlblok.Text = $"DVVT: {dvtOkCount}";
                   dvtlabelnotok.Text = $"DVVT: {dvtNotOkCount}";
                   dvtlabelongoing.Text = $"DVVT: {dvtOngoingCount}";

                   rmachart.Controls.Add(rmaPieChart);
                   rmaPieChart.Dock = DockStyle.Fill;

                   dvtchart.Controls.Add(dvtPieChart);
                   dvtPieChart.Dock = DockStyle.Fill;

               }
        */
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Class_Database classdatabase = new Class_Database();
            Chart customerChart = classdatabase.GenerateCustomerChart();
            Chart rmaPieChart = classdatabase.GenerateRMAPieChart();
            Chart dvtPieChart = classdatabase.GenerateDVTPieChart();

            if (customerChart != null)
            {
                rdcustomerchart.Controls.Add(customerChart);
                customerChart.Dock = DockStyle.Fill;
            }

            DataTable rmaData = classdatabase.SelectADD();
            DataTable dvtData = classdatabase.SelectDVT();

            if (rmaData != null && dvtData != null)
            {
                int rmaCustomerCount = rmaData.Rows.Count;
                int dvtCustomerCount = dvtData.Rows.Count;

              
                                int rmaOkCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");
                                int rmaNotOkCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");
                                int rmaOngoingCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

                                int dvtOkCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");
                                int dvtNotOkCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");
                                int dvtOngoingCount = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

                    /*
                              int rmaCount = rmaData.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>("Status")));

                              int dvtCount = dvtData.AsEnumerable().Count(row => !string.IsNullOrEmpty(row.Field<string>("Status")));
                    */

                rmalabel.Text = $"RMA: {rmaCustomerCount}";
                dvtlabel.Text = $"DVVT: {dvtCustomerCount}";

                rmalabelok.Text = $"RMA: {rmaOkCount}";
                rmalabelnotok.Text = $"RMA: {rmaNotOkCount}";
               rmalabelongoing.Text = $"RMA: {rmaOngoingCount}";

                dvtlblok.Text = $"DVVT: {dvtOkCount}";
                dvtlabelnotok.Text = $"DVVT: {dvtNotOkCount}";
               dvtlabelongoing.Text = $"DVVT: {dvtOngoingCount}";
            }

            if (rmaPieChart != null)
            {
                rmachart.Controls.Add(rmaPieChart);
                rmaPieChart.Dock = DockStyle.Fill;
            }

            if (dvtPieChart != null)
            {
                dvtchart.Controls.Add(dvtPieChart);
                dvtPieChart.Dock = DockStyle.Fill;
            }
        }
    }
}

