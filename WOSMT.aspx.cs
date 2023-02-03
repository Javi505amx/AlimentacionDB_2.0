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
    public partial class WOSMT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = this.ddlFunction.SelectedValue;
            this.Session["operation"] = (object)selectedValue;
            if (selectedValue == "Create")
            {
                this.txtWorkOrder.Enabled = true;
                this.txtWorkOrder.Focus();
                this.txtModel.Enabled = true;
                this.txtQty.Enabled = true;
                this.txtInitialSN.Enabled = true;
                this.txtFinalSN.Enabled = true;
            }
            else
            {
                if (!(selectedValue == "Update"))
                    return;
                this.txtWorkOrder.Enabled = true;
                this.txtWorkOrder.Focus();
                this.txtModel.Enabled = false;
                this.txtQty.Enabled = false;
                this.txtInitialSN.Enabled = false;
                this.txtFinalSN.Enabled = false;
            }
        }

        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            string text = this.txtWorkOrder.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            if (this.Session["operation"].ToString() == "Create")
            {
                this.btnSave.Visible = true;
                this.btnCancel.Visible = true;
                this.txtModel.Focus();
            }
            else
            {
                if (!(this.Session["operation"].ToString() == "Update"))
                    return;
                this.btnSave.Visible = true;
                this.btnCancel.Visible = true;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("GetInfoWOSMT", connection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection.Open();
                sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text;
                SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
                sqlDataReader.Read();
                try
                {
                    string str1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Model"));
                    int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                    string str2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("InitialSN"));
                    string str3 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FinalSN"));
                    connection.Close();
                    this.txtWorkOrder.Enabled = false;
                    this.txtModel.Enabled = true;
                    this.txtQty.Enabled = true;
                    this.txtInitialSN.Enabled = true;
                    this.txtFinalSN.Enabled = true;
                    this.txtModel.Text = str1;
                    this.txtQty.Text = int32.ToString();
                    this.txtInitialSN.Text = str2;
                    this.txtFinalSN.Text = str3;
                    this.txtModel.Focus();
                }
                catch
                {
                    this.lblResult.Text = "Work Order no encontrada";
                    this.lblResult.ForeColor = Color.Red;
                    this.txtWorkOrder.Text = "";
                    this.txtModel.Text = "";
                    this.txtQty.Text = "";
                    this.txtInitialSN.Text = "";
                    this.txtFinalSN.Text = "";
                    this.txtWorkOrder.Enabled = true;
                    this.txtWorkOrder.Focus();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string text1 = this.txtWorkOrder.Text;
            string text2 = this.txtModel.Text;
            string text3 = this.txtInitialSN.Text;
            string text4 = this.txtFinalSN.Text;
            int num = int.Parse(this.txtQty.Text);
            if (this.Session["operation"].ToString() == "Create")
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("AddInfoWOSMT", connection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                connection.Open();
                sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text1;
                sqlCommand2.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)text2;
                sqlCommand2.Parameters.Add("@Quantity", SqlDbType.Int).Value = (object)num;
                sqlCommand2.Parameters.Add("@InitialSN", SqlDbType.VarChar, 100).Value = (object)text3;
                sqlCommand2.Parameters.Add("@FinalSN", SqlDbType.VarChar, 100).Value = (object)text4;
                SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
                sqlDataReader.Read();
                int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("rowAffected"));
                connection.Close();
                if (int32 == 1)
                {
                    this.lblResult.Text = "Work Order Guardada";
                    this.lblResult.ForeColor = Color.Green;
                    this.txtWorkOrder.Text = "";
                    this.txtModel.Text = "";
                    this.txtQty.Text = "";
                    this.txtInitialSN.Text = "";
                    this.txtFinalSN.Text = "";
                    this.txtWorkOrder.Focus();
                }
                else
                {
                    if (int32 != 0)
                        return;
                    this.lblResult.Text = "Work Order Ya Registrada";
                    this.lblResult.ForeColor = Color.Red;
                    this.txtWorkOrder.Text = "";
                    this.txtModel.Text = "";
                    this.txtQty.Text = "";
                    this.txtInitialSN.Text = "";
                    this.txtFinalSN.Text = "";
                    this.txtWorkOrder.Focus();
                    this.ddlFunction.SelectedValue = "0";
                }
            }
            else
            {
                if (!(this.Session["operation"].ToString() == "Update"))
                    return;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand sqlCommand3 = new SqlCommand("UpdateInfoWOSMT", connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand4 = sqlCommand3;
                connection.Open();
                sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = (object)text1;
                sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = (object)text2;
                sqlCommand4.Parameters.Add("@Quantity", SqlDbType.Int).Value = (object)num;
                sqlCommand4.Parameters.Add("@InitialSN", SqlDbType.VarChar, 100).Value = (object)text3;
                sqlCommand4.Parameters.Add("@FinalSN", SqlDbType.VarChar, 100).Value = (object)text4;
                sqlCommand4.ExecuteReader().Read();
                connection.Close();
                this.lblResult.Text = "Work Order Actualizada";
                this.lblResult.ForeColor = Color.Green;
                this.txtWorkOrder.Text = "";
                this.txtModel.Text = "";
                this.txtQty.Text = "";
                this.txtInitialSN.Text = "";
                this.txtFinalSN.Text = "";
                this.txtWorkOrder.Focus();
                this.ddlFunction.SelectedValue = "0";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = "";
            this.txtWorkOrder.Text = "";
            this.txtModel.Text = "";
            this.txtQty.Text = "";
            this.txtInitialSN.Text = "";
            this.txtFinalSN.Text = "";
            this.txtWorkOrder.Enabled = false;
            this.txtModel.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtInitialSN.Enabled = false;
            this.txtFinalSN.Enabled = false;
            this.ddlFunction.SelectedValue = "0";
        }
    }
}