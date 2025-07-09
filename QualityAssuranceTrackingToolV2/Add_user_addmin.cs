using QualityAssuranceTrackingToolV2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;
using static QualityAssuranceTrackingToolV2.Class.Class_Database;

namespace QualityAssuranceTrackingToolV2
{
    public partial class Add_user_addmin : Form
    {
        public Add_user_addmin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Edit(true);
                appData.tablelogin.AddtableloginRow(appData.tablelogin.NewtableloginRow());
                tableloginBindingSource.MoveLast();
                usertb.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                appData.tablelogin.RejectChanges();
            }
        }
        private void Add_user_addmin_Load(object sender, EventArgs e)
        {
            tableadmin.DataSource = classdatabase.SelectAdmin();
        }
        private void Edit(bool value)
        {
           usertb.Enabled = value;
           passtb.Enabled = value;
            rolecb.Enabled = value;

        }
        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView control
                if (tableadmin.SelectedRows.Count > 0)
                {
                    // Retrieve the ID of the selected row
                    int ID = Convert.ToInt32(tableadmin.CurrentRow.Cells["ID"].Value);

                    // Call the EditAdmin method to update the record in the database
                    if (classdatabase.EditAdmin(usertb.Text, passtb.Text, rolecb.SelectedItem.ToString(), ID))
                    {
                        // Refresh the data in the DataGridView control
                        tableadmin.DataSource = classdatabase.SelectAdmin();
                        tableadmin.Refresh();

                        MessageBox.Show("Your Data has been Edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                appData.tablelogin.RejectChanges();
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usertb.Text;
                string password = passtb.Text;
                string role = rolecb.SelectedItem?.ToString();

                // Verify that all required fields have input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please enter values for username, password, and role.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (classdatabase.SaveAdmin(username, password, role))
                {
                    // Refresh immediately
                    tableadmin.DataSource = classdatabase.SelectAdmin();
                    tableadmin.Refresh();

                    usertb.Focus();
                    MessageBox.Show("Your Data has been Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                appData.tablelogin.RejectChanges();
            }
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                int ID = Convert.ToInt32(tableadmin.CurrentRow.Cells["ID"].Value);
                string username = tableadmin.CurrentRow.Cells["Username"].Value.ToString();
                string password = tableadmin.CurrentRow.Cells["Password"].Value.ToString();
                string role = tableadmin.CurrentRow.Cells["Role"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (classdatabase.DeleteAdmin(username, password, role, ID))
                    {
                        tableadmin.DataSource = classdatabase.SelectAdmin();
                        tableadmin.Refresh();

                        MessageBox.Show("Record deleted successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Edit(false);
            tableloginBindingSource.ResetBindings(false);
            appData.tablelogin.RejectChanges();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HomePage2 h = new HomePage2(" ");
            h.Show();
            this.Hide();
        }
        private void tableadmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)    
            {
                DataGridViewRow row = this.tableadmin.Rows[e.RowIndex];

                //para maview yung data sa datagrid
                string username = row.Cells["Username"].Value.ToString();
                string password = row.Cells["Password"].Value.ToString();
                string role = row.Cells["Role"].Value.ToString();

                //ipapakita dun sa mga textbox at combobox yung data na galing sa table
                usertb.Text = username;
                passtb.Text = password;
                rolecb.SelectedItem = role;
            }
        }
    }
}
