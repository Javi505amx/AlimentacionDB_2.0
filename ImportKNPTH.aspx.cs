using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace AlimentacionDB_2._0
{
    public partial class ImportKNPTH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["pth"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetLastWOPTH", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                this.GridView1.DataSource = (object)sqlCommand.ExecuteReader();
                this.GridView1.DataBind();
                connection.Close();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
          if (this.fuData.PostedFile != null)
          {
            if (this.fuData.PostedFile.FileName != "")
            {
              try
              {
                string filename = this.Server.MapPath("~/UploadFile/" + this.fuData.FileName);
                this.fuData.SaveAs(filename);
                using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", (object) filename)))
                {
                  OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM [Hoja1$] WHERE WorkOrder <> ''", connection);
                  connection.Open();
                  new SqlBulkCopy(ConfigurationManager.ConnectionStrings["material"].ConnectionString)
                  {
                    DestinationTableName = "MaterialToSupply",
                    ColumnMappings = {
                      {
                        "WorkOrder",
                        "WorkOrder"
                      },
                      {
                        "PartNumber",
                        "PartNumber"
                      },
                      {
                        "Description",
                        "Description"
                      },
                      {
                        "Quantity",
                        "Quantity"
                      }
                    }
                  }.WriteToServer((DbDataReader) oleDbCommand.ExecuteReader());
                  this.BindGridView();
                  connection.Close();
                  this.Response.Write("<script language='Javascript'>alert('Archivo importado con exito');</script>");
                  return;
                }
              }
              catch (Exception ex)
              {
                this.Response.Write("<script language='Javascript'>alert('" + ex.Message + "');</script>");
                return;
              }
            }
          }
          this.Response.Write("<script language='Javascript'>alert('Sin archivo seleccionado');</script>"); 
        }
    }
}