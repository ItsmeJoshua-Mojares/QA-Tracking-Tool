using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static QualityAssuranceTrackingToolV2.Class.Class_Global;
using static QualityAssuranceTrackingToolV2.Class.TestingDB;


namespace QualityAssuranceTrackingToolV2.Class
{
    public class TestingDB : IDatabase
    {
        SqlConnection con;
  
        public static string type;
        public TestingDB(string datasource, string userID, string password, string Database)
        {

            con = new SqlConnection($"Data Source={datasource}; Database={Database};user ID={userID};password={password}");

        }

        public TestingDB()
        {
        }

        public interface IDatabase
        {
            bool connected();
            bool SaveAdmin(string username, string password, string role);
            // Iba pang mga methods
        }
        public virtual bool connected()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Open();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }


        //RMA
        public DataTable SelectADD(string v)
        {
            con.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM TableRMA";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);
            con.Close();
            return dt;
        }
        public bool DeleteADD(int ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TableRMA WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("RMA Deleted Successfully");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool EditADD(string customer, string address, string product, string UnitSerialNo, string findings, string status, DateTime DateReceived, string issues, string solution, string remarks, Image Photo, int ID)
        {
            try
            {
                con.Open();
                string query = "UPDATE TableRMA SET Customer=@Customer, Address=@Address, Product=@Product, UnitSerialNo=@UnitSerialNo, Findings=@Findings, Status=@Status, DateReceived=@DateReceived, Issues=@Issues, Solution=@Solution, Remarks=@Remarks, Photo=@Photo WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Customer", customer);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Product", product);
                command.Parameters.AddWithValue("@UnitSerialNo", UnitSerialNo);
                command.Parameters.AddWithValue("@Findings", findings);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DateReceived", DateReceived);
                command.Parameters.AddWithValue("@Issues", issues);
                command.Parameters.AddWithValue("@Solution", solution);
                command.Parameters.AddWithValue("@Remarks", remarks);
                command.Parameters.AddWithValue("@Photo", ImageToByteArray(Photo));
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertADD(string customer, string address, string product, string UnitSerialNo, string findings, string status, DateTime DateReceived, string issues, string solution, string remarks, Image Photo)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TableRMA (Customer, Address, Product, UnitSerialNo, Findings, Status, DateReceived, Issues, Solution, Remarks, Photo) VALUES (@Customer, @Address, @Product, @UnitSerialNo, @Findings, @Status, @DateReceived, @Issues, @Solution, @Remarks, @Photo)", con);
                cmd.Parameters.AddWithValue("@Customer", customer);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Product", product);
                cmd.Parameters.AddWithValue("@UnitSerialNo", UnitSerialNo);
                cmd.Parameters.AddWithValue("@Findings", findings);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@DateReceived", DateReceived);
                cmd.Parameters.AddWithValue("@Issues", issues);
                cmd.Parameters.AddWithValue("@Solution", solution);
                cmd.Parameters.AddWithValue("@Remarks", remarks);
                cmd.Parameters.AddWithValue("@Photo", ImageToByteArray(Photo));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been added to the TableRMA table.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Login
        public bool Login(string Username, string Password, out string Role)
        {
            Role = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TblLogin WHERE Username = @Username AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Role = dr["Role"].ToString();

                    // Set the global type based on the role
                    Class_Global.type = Role;

                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    Role = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Role = null;
                return false;
            }
        }
        public DataTable SelectAdmin()
        {
            con.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM TblLogin";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);
            con.Close();
            return dt;
        }
        public bool EditAdmin(string Username, string Password, string Role, int ID)
        {
            try
            {
                con.Open();
                string query = "UPDATE TblLogin SET Username = @Username, Password = @Password, Role = @Role WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Role", Role);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteAdmin(string Username, string Password, string Role, int ID)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM TblLogin WHERE Username='" + Username + "'";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("RMA Deleted Successfully");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool SaveAdmin(string Username, string Password, string Role, string v)
        {

            try
            {
                con.Open();

                string query = "INSERT INTO TblLogin (Username, Password, Role) " +
                               "VALUES (@Username, @Password, @Role)";

                SqlCommand sqlCommand = new SqlCommand(query, con);

                sqlCommand.Parameters.AddWithValue("@Username", Username);
                sqlCommand.Parameters.AddWithValue("@Password", Password);
                sqlCommand.Parameters.AddWithValue("@Role", Role);

                sqlCommand.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }


        //Search
        public DataTable SearchADD(string searchText)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string query = "SELECT * FROM TableRMA WHERE Customer LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%' OR Product LIKE '%" + searchText + "%' OR UnitSerialNo LIKE '%" + searchText + "%'";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable SearchDVT(string searchText)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string query = "SELECT * FROM TableDVT1 WHERE Customer LIKE '%" + searchText + "%' OR Address LIKE '%" + searchText + "%' OR Product LIKE '%" + searchText + "%' OR UnitSerialNo LIKE '%" + searchText + "%'";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        //DVT
        public void InsertDVT(string customer, string address, string product, string UnitSerialNo, string findings, string classification, string status, DateTime DateReceived, string issues, string solution, string remarks, Image Photo)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TableDVT1 (Customer, Address, Product, UnitSerialNo, Findings, Classification, Status, DateReceived, Issues, Solution, Remarks, Photo) VALUES (@Customer, @Address, @Product, @UnitSerialNo, @Findings, @Classification, @Status, @DateReceived, @Issues, @Solution, @Remarks, @Photo)", con);
                cmd.Parameters.AddWithValue("@Customer", customer);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Product", product);
                cmd.Parameters.AddWithValue("@UnitSerialNo", UnitSerialNo);
                cmd.Parameters.AddWithValue("@Findings", findings);
                cmd.Parameters.AddWithValue("@Classification", classification);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@DateReceived", DateReceived);
                cmd.Parameters.AddWithValue("@Issues", issues);
                cmd.Parameters.AddWithValue("@Solution", solution);
                cmd.Parameters.AddWithValue("@Remarks", remarks);
                cmd.Parameters.AddWithValue("@Photo", ImageToByteArray(Photo));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been added to the TableDVT table.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable SelectDVT()
        {
            con.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM TableDVT1 ";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);
            con.Close();
            return dt;
        }
        public bool EditDVT(string customer, string address, string product, string UnitSerialNo, string findings, string classification, string status, DateTime DateReceived, string issues, string solution, string remarks, Image Photo, int ID)
        {
            try
            {
                con.Open();
                string query = "UPDATE TableDVT1 SET Customer=@Customer, Address=@Address, Product=@Product, UnitSerialNo=@UnitSerialNo, Findings=@Findings, Classification=@Classification, Status=@Status, DateReceived=@DateReceived, Issues=@Issues, Solution=@Solution, Remarks=@Remarks, Photo=@Photo WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Customer", customer);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Product", product);
                command.Parameters.AddWithValue("@UnitSerialNo", UnitSerialNo);
                command.Parameters.AddWithValue("@Findings", findings);
                command.Parameters.AddWithValue("@Classification", classification);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DateReceived", DateReceived);
                command.Parameters.AddWithValue("@Issues", issues);
                command.Parameters.AddWithValue("@Solution", solution);
                command.Parameters.AddWithValue("@Remarks", remarks);
                command.Parameters.AddWithValue("@Photo", ImageToByteArray(Photo));
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteDVT(int ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TableDVT1 WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DVT Deleted Successfully");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Dashboard
        public Chart GenerateCustomerChart()
        {
            Chart chart = new Chart();
            // Set the chart area
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Create series for RMA and DVT
            Series seriesRMA = new Series("RMA");
            Series seriesDVT = new Series("DVT");

            // Add the series to the chart
            chart.Series.Add(seriesRMA);
            chart.Series.Add(seriesDVT);

            // Set chart type to bar
            seriesRMA.ChartType = SeriesChartType.Bar;
            seriesDVT.ChartType = SeriesChartType.Bar;

            // Get the data from the database
            DataTable rmaData = SelectADD();
            DataTable dvtData = SelectDVT();

            // Count customers for RMA
            int rmaCustomerCount = rmaData.Rows.Count;

            // Count customers for DVT
            int dvtCustomerCount = dvtData.Rows.Count;

            // Add data points to the series
            seriesRMA.Points.AddXY(" ", rmaCustomerCount);
            seriesDVT.Points.AddXY(" ", dvtCustomerCount);

            // Set colors for the series
            seriesRMA.Color = Color.Blue;
            seriesDVT.Color = Color.Red;

            // Add legend
            Legend legend = new Legend();
            chart.Legends.Add(legend);

            // Assign series to the legend
            seriesRMA.Legend = legend.Name;
            seriesDVT.Legend = legend.Name;

            // Set legend titles
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Wide;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.BackColor = Color.Transparent;

            // Set the title for the chart
            chart.Titles.Add("Customer Count");

            return chart;
        }

        private DataTable SelectADD()
        {
            throw new NotImplementedException();
        }

        public Chart GenerateRMAPieChart()
        {
            // Create a new chart
            Chart pieChart = new Chart();

            // Set the chart area
            ChartArea chartArea = new ChartArea();
            pieChart.ChartAreas.Add(chartArea);

            // Create a series for the pie chart
            Series series = new Series("RMAStatus");
            pieChart.Series.Add(series);

            // Set chart type to pie
            series.ChartType = SeriesChartType.Pie;

            // Get the data from the RMA table
            DataTable rmaData = SelectADD();

            // Count occurrences of each status
            int okCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");
            int notOkCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");
            int ongoingCount = rmaData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

            // Add data points to the series
            series.Points.AddXY(" OK ", okCount);
            series.Points.AddXY(" NOT OK ", notOkCount);
            series.Points.AddXY(" ON GOING ", ongoingCount);

            // Set colors for each status
            series.Points[0].Color = Color.Blue;    // OK
            series.Points[1].Color = Color.Red;     // NOT OK
            series.Points[2].Color = Color.Green;   // ON GOING

            // Set the title for the chart
            pieChart.Titles.Add("RMA Status ");

            // Add a legend 
            Legend legend = new Legend();
            pieChart.Legends.Add(legend);

            // Assign series to the legend
            series.Legend = legend.Name;

            // Set legend titles
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Wide;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.BackColor = Color.Transparent;
            return pieChart;
        }
        public Chart GenerateDVTPieChart()
        {
            // Create a new chart
            Chart pieChart = new Chart();

            // Set the chart area
            ChartArea chartArea = new ChartArea();
            pieChart.ChartAreas.Add(chartArea);

            // Create a series for the pie chart
            Series series = new Series("DVTStatus");
            pieChart.Series.Add(series);

            // Set chart type to pie
            series.ChartType = SeriesChartType.Pie;

            // Get the data from the RMA table
            DataTable dvtData = SelectDVT();

            // Count occurrences of each status
            int okCount1 = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "OK");
            int notOkCount1 = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "NOT OK");
            int ongoingCount1 = dvtData.AsEnumerable().Count(row => row.Field<string>("Status") == "ON GOING");

            // Add data points to the series
            series.Points.AddXY(" OK ", okCount1);
            series.Points.AddXY(" NOT OK ", notOkCount1);
            series.Points.AddXY(" ON GOING ", ongoingCount1);

            // Set colors for each status
            series.Points[0].Color = Color.Blue;    // OK
            series.Points[1].Color = Color.Red;     // NOT OK
            series.Points[2].Color = Color.Green;   // ON GOING

            // Set the title for the chart
            pieChart.Titles.Add("DVT Status ");

            // Add a legend
            Legend legend = new Legend();
            pieChart.Legends.Add(legend);

            // Assign series to the legend
            series.Legend = legend.Name;

            // Set legend titles
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Wide;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.BackColor = Color.Transparent;
            return pieChart;
        }

        bool IDatabase.SaveAdmin(string username, string password, string role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteADD(string v)
        {
            throw new NotImplementedException();
        }

        public bool SaveAdmin(string username, string password, string role)
        {
            throw new NotImplementedException();
        }

        //Search by Date

    }
}
