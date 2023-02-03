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
    public partial class AlternateNP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindGridView()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["smt"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetLastWOAlterns", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                GridView1.DataSource = (object)sqlCommand.ExecuteReader();
                GridView1.DataBind();
                connection.Close();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuData.PostedFile != null)
            {
                if (fuData.PostedFile.FileName != "")
                {
                    try
                    {
                        string filename = Server.MapPath("~/UploadFile/" + fuData.FileName);
                        fuData.SaveAs(filename);
                        using (OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", (object)filename)))
                        {
                            OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM [Hoja1$] WHERE WorkOrder <> ''", connection);
                            connection.Open();
                            new SqlBulkCopy(ConfigurationManager.ConnectionStrings["smt"].ConnectionString)
                            {
                                DestinationTableName = "AlternateParts",
                                ColumnMappings = {
                  {
                    "WorkOrder",
                    "WorkOrder"
                  },
                  {
                    "KittingNote",
                    "KittingNote"
                  },
                  {
                    "Model",
                    "Model"
                  },
                  {
                    "PartNumber",
                    "PartNumber"
                  },
                  {
                    "AlternatePartNumber",
                    "AlternatePartNumber"
                  },
                  {
                    "ECN",
                    "ECN"
                  }
                }
                            }.WriteToServer((DbDataReader)oleDbCommand.ExecuteReader());
                           // BindGridView();
                            connection.Close();
                            Response.Write("<script language='Javascript'>alert('Archivo importado con exito');</script>");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language='Javascript'>alert('" + ex.Message + "');</script>");
                        return;
                    }
                }
            }
            Response.Write("<script language='Javascript'>alert('Sin archivo seleccionado');</script>");
        }
    }
}