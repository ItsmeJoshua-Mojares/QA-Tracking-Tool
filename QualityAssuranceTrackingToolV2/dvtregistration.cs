using QualityAssuranceTrackingToolV2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;
using static QualityAssuranceTrackingToolV2.Class.Class_Database;

namespace QualityAssuranceTrackingToolV2
{
    public partial class dvtregistration : Form
    {
        public dvtregistration()
        {
            InitializeComponent();
        }
        private void adddvtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any of the textboxes or comboboxes are empty
                if (string.IsNullOrEmpty(customerdvttb.Text) || string.IsNullOrEmpty(addressdvttb.Text) || string.IsNullOrEmpty(productdvttb.Text) || string.IsNullOrEmpty(unsdvttb.Text) || findingsdvtcb.SelectedItem == null || classificationaldvtcb.SelectedItem == null || statusdvtcb.SelectedItem == null || string.IsNullOrEmpty(issuesdvttb.Text) || string.IsNullOrEmpty(solutiondvttb.Text) || string.IsNullOrEmpty(remarksdvttb.Text) || pictureBoxImage1.Image == null)
                {
                    MessageBox.Show("Please fill in all the required fields.");
                    return;
                }

                // Convert the image to a byte array
                byte[] imageBytes = ImageToByteArray(pictureBoxImage1.Image);

                // Insert the data into the database
                classdatabase.InsertDVT(customerdvttb.Text, addressdvttb.Text, productdvttb.Text, unsdvttb.Text, findingsdvtcb.SelectedItem.ToString(), classificationaldvtcb.SelectedItem.ToString(), statusdvtcb.SelectedItem.ToString(), daterdvtdr.Value, issuesdvttb.Text, solutiondvttb.Text, remarksdvttb.Text, imageBytes);//pictureBoxImage1.Image);

                // Refresh the data in the DataGridView
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        /*
         private void populate()
         {

             DataTable dt = classdatabase.SelectDVT();
             griddvt.DataSource = dt;
             griddvt.Refresh();

             DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)griddvt.Columns[12];
             imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
             griddvt.RowTemplate.Height = 20;
         }
        */
        private void populate()
        {
            DataTable dt = classdatabase.SelectDVT();
            griddvt.DataSource = dt;
            griddvt.Refresh();

            // Check if the column exists before accessing it
            if (griddvt.Columns.Count > 12)
            {
                DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)griddvt.Columns[12];
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            griddvt.RowTemplate.Height = 20;
        }
        private void editdvtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (griddvt.SelectedRows.Count > 0)
                {
                    // Check if the required TextBox and ComboBox fields have values
                    if (IsInputValid())
                    {
                        // Retrieve the ID of the selected row
                        int ID = Convert.ToInt32(griddvt.CurrentRow.Cells["ID"].Value);

                        // Assuming 'pictureBoxImage' is your PictureBox control
                        Image image = pictureBoxImage1.Image;
                        byte[] imageBytes = ImageToByteArray(image);

                        // Call the EditDVT method to update the record in the database
                        classdatabase.EditDVT(customerdvttb.Text, addressdvttb.Text, productdvttb.Text, unsdvttb.Text, findingsdvtcb.SelectedItem.ToString(), classificationaldvtcb.SelectedItem.ToString(), statusdvtcb.SelectedItem.ToString(), daterdvtdr.Value, issuesdvttb.Text, solutiondvttb.Text, remarksdvttb.Text, imageBytes, ID );//pictureBoxImage1.Image, ID);

                        // Refresh the data in the DataGridView control
                        griddvt.DataSource = classdatabase.SelectDVT();
                        griddvt.Refresh();

                        MessageBox.Show("DVT Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please double click the Photo before we proceed to edit..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to edit.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsInputValid()
        {
            // Add validation logic for TextBox and ComboBox fields
            return !string.IsNullOrEmpty(customerdvttb.Text) &&
                   !string.IsNullOrEmpty(addressdvttb.Text) &&
                   !string.IsNullOrEmpty(productdvttb.Text) &&
                   !string.IsNullOrEmpty(unsdvttb.Text) &&
                   findingsdvtcb.SelectedItem != null &&
                   classificationaldvtcb.SelectedItem != null &&
                   statusdvtcb.SelectedItem != null;
        }
        private void deletedvtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (griddvt.SelectedRows.Count > 0)
                {
                    // Retrieve the ID of the selected row
                    int ID = Convert.ToInt32(griddvt.CurrentRow.Cells["ID"].Value);

                    // Call the DeleteADD method to delete the record from the database
                    if (classdatabase.DeleteDVT(ID))
                    {
                        // Refresh the data in the DataGridView control
                        griddvt.DataSource = classdatabase.SelectDVT();
                        griddvt.Refresh();

                        MessageBox.Show("DVT Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void backdvtbtn_Click(object sender, EventArgs e)
        {
            HomePage2 homePage2 = new HomePage2(" ");
            homePage2.Show();
            this.Close();
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
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.griddvt.Rows[e.RowIndex];

                    // Extract the data from the selected row
                    string customer = row.Cells["Customer"].Value.ToString();
                    string address = row.Cells["Address"].Value.ToString();
                    string product = row.Cells["Product"].Value.ToString();
                    string unitSerialNo = row.Cells["UnitSerialNo"].Value.ToString();
                    string findings = row.Cells["Findings"].Value.ToString();
                    string classification = row.Cells["classification"].Value.ToString();
                    string status = row.Cells["Status"].Value.ToString();
                    DateTime dateReceived = Convert.ToDateTime(row.Cells["DateReceived"].Value);
                    string issues = row.Cells["Issues"].Value.ToString();
                    string solution = row.Cells["Solution"].Value.ToString();
                    string remarks = row.Cells["Remarks"].Value.ToString();
                    byte[] photoBytes = (byte[])row.Cells["Photo"].Value;
                    Image photo = ByteArrayToImage(photoBytes);

                    // Display the data in the textboxes and combo boxes
                    customerdvttb.Text = customer;
                    addressdvttb.Text = address;
                    productdvttb.Text = product;
                    unsdvttb.Text = unitSerialNo;
                    findingsdvtcb.SelectedItem = findings;
                    classificationaldvtcb.SelectedItem = classification;
                    statusdvtcb.SelectedItem = status;
                    daterdvtdr.Value = dateReceived;
                    issuesdvttb.Text = issues;
                    solutiondvttb.Text = solution;
                    remarksdvttb.Text = remarks;

                    // Optionally, display the image in a PictureBox
                    pictureBoxImage1.Image = photo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dvtregistration_Load(object sender, EventArgs e)   
        {
            griddvt.DataSource = classdatabase.SelectDVT();
            populate();
        }
        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Uploadbtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
    }

