using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AlimentacionDB_2._0
{
    public partial class WOPTH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            string text = txtWorkOrder.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["pth"].ConnectionString;
            if (Session["operation"].ToString() == "Create")
            {
                btnSave.Visible = true;
                btnCancel.Visible = true;
                txtModel.Focus();
            }
            else
            {
                if (!(Session["operation"].ToString() == "Update"))
                    return;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("GetInfoWOPTH2", connection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection.Open();
                sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text;
                SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
                sqlDataReader.Read();
                try
                {
                    string str1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Model"));
                    int int32_1 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                    string str2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Main"));
                    int int32_2 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Rate"));
                    decimal ratemin = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("RateMin"));
                    connection.Close();
                    txtWorkOrder.Enabled = false;
                    txtModel.Enabled = true;
                    txtQty.Enabled = true;
                    txtRate.Enabled = true;
                    txtMain.Enabled = true;
                    txtModel.Text = str1;
                    txtRateMin.Enabled = true;
                    txtQty.Text = int32_1.ToString();
                    txtMain.Text = str2;
                    txtRate.Text = int32_2.ToString();
                    txtModel.Focus();
                    txtRateMin.Text = ratemin.ToString();
                }
                catch
                {
                    lblResult.Text = "Work Order no encontrada";
                    lblResult.ForeColor = Color.Red;
                    txtWorkOrder.Text = "";
                    txtModel.Text = "";
                    txtQty.Text = "";
                    txtMain.Text = "";
                    txtRate.Text = "";
                    txtWorkOrder.Enabled = true;
                    txtWorkOrder.Focus();
                }
            }
        }

        protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlFunction.SelectedValue;
            Session["operation"] = (object)selectedValue;
            if (selectedValue == "Create")
            {
                txtWorkOrder.Enabled = true;
                txtWorkOrder.Focus();
                txtModel.Enabled = true;
                txtQty.Enabled = true;
                txtMain.Enabled = true;
                txtRate.Enabled = true;
                txtRateMin.Enabled = true;            
            }
            else
            {
                if (!(selectedValue == "Update"))
                    return;
                txtWorkOrder.Enabled = true;
                txtWorkOrder.Focus();
                txtModel.Enabled = false;
                txtQty.Enabled = false;
                txtMain.Enabled = false;
                txtRate.Enabled = false;
                txtRateMin.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pth"].ConnectionString;
            string text1 = txtWorkOrder.Text;
            string text2 = txtModel.Text;
            string text3 = txtMain.Text;
            int num1 = int.Parse(txtQty.Text);
            int num2 = int.Parse(txtRate.Text);
            if (Session["operation"].ToString() == "Create")
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("AddInfoWOPTH", connection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection.Open();
                sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text1;
                sqlCommand2.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)text2;
                sqlCommand2.Parameters.Add("@Quantity", SqlDbType.Int).Value = (object)num1;
                sqlCommand2.Parameters.Add("@Main", SqlDbType.VarChar, 100).Value = (object)text3;
                sqlCommand2.Parameters.Add("@Rate", SqlDbType.Int).Value = (object)num2;
                sqlCommand2.Parameters.Add("@RateMin", SqlDbType.Decimal).Value = txtRateMin.Text;
                SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
                sqlDataReader.Read();
                int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("rowAffected"));
                connection.Close();
                if (int32 == 1)
                {
                    lblResult.Text = "Work Order Guardada";
                    lblResult.ForeColor = Color.Green;
                    txtWorkOrder.Text = "";
                    txtModel.Text = "";
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtMain.Text = "";
                    txtWorkOrder.Focus();
                }
                else
                {
                    if (int32 != 0)
                        return;
                    lblResult.Text = "Work Order Ya Registrada";
                    lblResult.ForeColor = Color.Red;
                    txtWorkOrder.Text = "";
                    txtModel.Text = "";
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtMain.Text = "";
                    txtWorkOrder.Focus();
                }
            }
            else
            {
                if (!(Session["operation"].ToString() == "Update"))
                    return;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("UpdateInfoWOPTH", connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand4 = sqlCommand3;
                connection.Open();
                sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text1;
                sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)text2;
                sqlCommand4.Parameters.Add("@Quantity", SqlDbType.Int).Value = (object)num1;
                sqlCommand4.Parameters.Add("@Main", SqlDbType.VarChar, 100).Value = (object)text3;
                sqlCommand4.Parameters.Add("@Rate", SqlDbType.Int).Value = (object)num2;
                sqlCommand4.ExecuteReader().Read();
                connection.Close();
                lblResult.Text = "Work Order Actualizada";
                lblResult.ForeColor = Color.Green;
                txtWorkOrder.Text = "";
                txtModel.Text = "";
                txtQty.Text = "";
                txtMain.Text = "";
                txtRate.Text = "";
                txtWorkOrder.Focus();
                ddlFunction.SelectedValue = "0";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            txtWorkOrder.Text = "";
            txtModel.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtMain.Text = "";
            txtWorkOrder.Enabled = false;
            txtModel.Enabled = false;
            txtQty.Enabled = false;
            txtRate.Enabled = false;
            txtMain.Enabled = false;
            ddlFunction.SelectedValue = "0";
        }
    }
}