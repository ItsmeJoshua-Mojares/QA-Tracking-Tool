using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;
using QualityAssuranceTrackingToolV2.Class;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;
using static QualityAssuranceTrackingToolV2.Class.Class_Database;

namespace QualityAssuranceTrackingToolV2
{
    public partial class rmaregistration : Form
    {
        public rmaregistration()
        {
            InitializeComponent();
        }
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null; // or throw an exception, depending on your requirements
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Change the format if needed
                return ms.ToArray();
            }
        }
        private void backrmabtn_Click_1(object sender, EventArgs e)
        {
            HomePage2 hme = new HomePage2(" ");
            hme.Show();
            this.Hide();
        }
        private void populate()
        {
            DataTable dt = classdatabase.SelectADD();
            gridrma.DataSource = dt;
            gridrma.Refresh();

            DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)gridrma.Columns[11];
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            gridrma.RowTemplate.Height = 20;
        } 
        private void gridrma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            customerrmatb.Text = gridrma.SelectedRows[0].Cells[0].Value.ToString();
            addressrmatb.Text = gridrma.SelectedRows[0].Cells[1].Value.ToString();
            productrmatb.Text = gridrma.SelectedRows[0].Cells[2].Value.ToString();
            unsrmatb.Text = gridrma.SelectedRows[0].Cells[3].Value.ToString();
            findingsrmacb.SelectedItem = gridrma.SelectedRows[0].Cells[4].Value.ToString();
            statusrmacb.SelectedItem = gridrma.SelectedRows[0].Cells[5].Value.ToString();
            datermadr.Text = gridrma.SelectedRows[0].Cells[6].Value.ToString();
            issuesrmatb.Text = gridrma.SelectedRows[0].Cells[7].Value.ToString();
            solutionrmatb.Text = gridrma.SelectedRows[0].Cells[8].Value.ToString();
            remarksrmatb.Text = gridrma.SelectedRows[0].Cells[9].Value.ToString();
        }
        private void deletermabtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (gridrma.SelectedRows.Count > 0)
                {
                    // Retrieve the ID of the selected row
                    int ID = Convert.ToInt32(gridrma.CurrentRow.Cells["ID"].Value);

                    // Call the DeleteADD method to delete the record from the database
                    if (classdatabase.DeleteADD(ID))
                    {
                        // Refresh the data in the DataGridView control
                        gridrma.DataSource = classdatabase.SelectADD();
                        gridrma.Refresh();

                        MessageBox.Show("RMA Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void editrmabtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (gridrma.SelectedRows.Count > 0)
                {
                    // Check if the required TextBox and ComboBox fields have values
                    if (IsInputValid())
                    {
                        // Retrieve the ID of the selected row
                        int ID = Convert.ToInt32(gridrma.CurrentRow.Cells["ID"].Value);

                        // Assuming 'pictureBoxImage' is your PictureBox control
                        Image image = pictureBoxImage.Image;
                        byte[] imageBytes = ImageToByteArray(image);

                        // Call the EditADD method to update the record in the database
                        classdatabase.EditADD(customerrmatb.Text, addressrmatb.Text, productrmatb.Text, unsrmatb.Text, findingsrmacb.SelectedItem.ToString(), statusrmacb.SelectedItem.ToString(), datermadr.Value, issuesrmatb.Text, solutionrmatb.Text, remarksrmatb.Text, pictureBoxImage.Image, ID);

                        // Refresh the data in the DataGridView control
                        gridrma.DataSource = classdatabase.SelectADD();
                        gridrma.Refresh();

                        MessageBox.Show("RMA Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please double click the Photo before we proceed to edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle specific SQL exceptions here
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void editrmabtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (gridrma.SelectedRows.Count > 0)
                {
                    // Check if the required TextBox and ComboBox fields have values
                    if (IsInputValid())
                    {
                        // Retrieve the ID of the selected row
                        int ID = Convert.ToInt32(gridrma.CurrentRow.Cells["ID"].Value);

                        // Assuming 'pictureBoxImage' is your PictureBox control
                        Image image = pictureBoxImage.Image;
                        byte[] imageBytes = ImageToByteArray(image); // Convert Image to byte array

                        // Call the EditADD method to update the record in the database
                        classdatabase.EditADD(customerrmatb.Text, addressrmatb.Text, productrmatb.Text, unsrmatb.Text, findingsrmacb.SelectedItem.ToString(), statusrmacb.SelectedItem.ToString(), datermadr.Value, issuesrmatb.Text, solutionrmatb.Text, remarksrmatb.Text, imageBytes, ID);

                        // Refresh the data in the DataGridView control
                        gridrma.DataSource = classdatabase.SelectADD();
                        gridrma.Refresh();

                        MessageBox.Show("RMA Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please double click the Photo before we proceed to edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle specific SQL exceptions here
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInputValid()
        {
            // Add validation logic for TextBox and ComboBox fields
            return !string.IsNullOrEmpty(customerrmatb.Text) &&
                   !string.IsNullOrEmpty(addressrmatb.Text) &&
                   !string.IsNullOrEmpty(productrmatb.Text) &&
                   !string.IsNullOrEmpty(unsrmatb.Text) &&
                   findingsrmacb.SelectedItem != null &&
                   statusrmacb.SelectedItem != null;
        }


        private void rmaregistration_Load(object sender, EventArgs e)
        {
            gridrma.DataSource = classdatabase.SelectADD();
            populate();
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        private void gridrma_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridrma.Rows[e.RowIndex];

                // Extract the data from the selected row
                string customer = row.Cells["Customer"].Value.ToString();
                string address = row.Cells["Address"].Value.ToString();
                string product = row.Cells["Product"].Value.ToString();
                string unitSerialNo = row.Cells["UnitSerialNo"].Value.ToString();
                string findings = row.Cells["Findings"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                DateTime dateReceived = Convert.ToDateTime(row.Cells["DateReceived"].Value);
                string issues = row.Cells["Issues"].Value.ToString();
                string solution = row.Cells["Solution"].Value.ToString();
                string remarks = row.Cells["Remarks"].Value.ToString();
                byte[] photoBytes = (byte[])row.Cells["Photo"].Value;
                Image photo = ByteArrayToImage(photoBytes);

                // Display the data in the textboxes and comboboxes
                customerrmatb.Text = customer;
                addressrmatb.Text = address;
                productrmatb.Text = product;
                unsrmatb.Text = unitSerialNo;
                findingsrmacb.SelectedItem = findings;
                statusrmacb.SelectedItem = status;
                datermadr.Value = dateReceived;
                issuesrmatb.Text = issues;
                solutionrmatb.Text = solution;
                remarksrmatb.Text = remarks;
                pictureBoxImage.Image = photo;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gridrma.Refresh();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Uploadbtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private void addrmabtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check if any of the textboxes or comboboxes are empty
                if (string.IsNullOrEmpty(customerrmatb.Text) || string.IsNullOrEmpty(addressrmatb.Text) || string.IsNullOrEmpty(productrmatb.Text) || string.IsNullOrEmpty(unsrmatb.Text) || findingsrmacb.SelectedItem == null || statusrmacb.SelectedItem == null || string.IsNullOrEmpty(issuesrmatb.Text) || string.IsNullOrEmpty(solutionrmatb.Text) || string.IsNullOrEmpty(remarksrmatb.Text) || pictureBoxImage.Image == null)
                {
                    MessageBox.Show("Please fill in all the required fields.");
                    return;
                }

                // Convert the image to a byte array
                byte[] imageBytes = ImageToByteArray(pictureBoxImage.Image);

                // Insert the data into the database
                classdatabase.InsertADD(customerrmatb.Text, addressrmatb.Text, productrmatb.Text, unsrmatb.Text, findingsrmacb.SelectedItem.ToString(), statusrmacb.SelectedItem.ToString(), datermadr.Value, issuesrmatb.Text, solutionrmatb.Text, remarksrmatb.Text, imageBytes); //pictureBoxImage.Image);

                // Refresh the data in the DataGridView
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void findingsrmacb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the DropDownStyle to DropDownList
            findingsrmacb.DropDownStyle = ComboBoxStyle.DropDownList;

            // Optional: I-check ang napiling item
            if (findingsrmacb.SelectedIndex != -1)
            {
                string selectedValue = findingsrmacb.SelectedItem.ToString();
                // Add additional logic here based on the selected item if needed
            }
        }

        private void remarksrmatb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

