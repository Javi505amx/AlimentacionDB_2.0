using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AlimentacionDB_2._0
{
    public partial class DeleteFS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            this.lblResult.Text = "";
            string upper = txtWorkOrder.Text.ToUpper();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetModelByWO", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection.Open();
            sqlCommand2.Parameters.Add("@WO", SqlDbType.VarChar, 50).Value = (object)upper;
            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            sqlDataReader.Read();
            try
            {
                this.lblModel.Text = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Model"));
                this.lblWorkOrder.Text = upper;
                this.lblModel.Visible = true;
                this.lblWorkOrder.Visible = true;
                this.btnDelete.Visible = true;
                this.btnCancel.Visible = true;
                this.txtWorkOrder.Enabled = false;
            }
            catch
            {
                this.lblModel.Visible = false;
                this.lblWorkOrder.Visible = false;
                this.btnDelete.Visible = false;
                this.btnCancel.Visible = false;
                this.txtWorkOrder.Enabled = true;
                this.txtWorkOrder.Focus();
                this.lblResult.Text = "No existe la WO ingresada";
                this.lblResult.ForeColor = System.Drawing.Color.Red;
            }
            connection.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string upper = this.lblWorkOrder.Text.ToUpper();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["smt"].ConnectionString);
            SqlCommand sqlCommand1 = new SqlCommand("DeleteFSByWO", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = (object)upper;
            sqlCommand2.ExecuteReader();
            connection.Close();
            this.lblWorkOrder.Visible = false;
            this.lblModel.Visible = false;
            this.lblResult.Visible = true;
            this.lblResult.ForeColor = System.Drawing.Color.Green;
            this.lblResult.Text = "FS Eliminado Correctamente";
            this.btnDelete.Visible = false;
            this.btnCancel.Visible = false;
            this.txtWorkOrder.Text = "";
            this.txtWorkOrder.Enabled = true;
            this.txtWorkOrder.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.lblWorkOrder.Text = "";
            this.lblModel.Text = "";
            this.btnCancel.Visible = false;
            this.btnDelete.Visible = false;
            this.txtWorkOrder.Enabled = true;
            this.txtWorkOrder.Text = "";
            this.txtWorkOrder.Focus();
        }


    }
}