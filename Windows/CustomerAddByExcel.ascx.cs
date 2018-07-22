using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

public partial class Windows_CustomerAddByExcel : System.Web.UI.UserControl
{
    CustomerClass custObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            bool flg = true;
            DataTable dtTemp = new DataTable();
            if (FileUpload1.FileName.ToString() != "")
            {
                FileUpload1.SaveAs(Server.MapPath("~/Windows/excelfiles/" + FileUpload1.FileName.ToString()));
                string fileName = Server.MapPath("~/Windows/excelfiles/" + FileUpload1.FileName.ToString());
                string SourceConstr = "";
                string ext = "";
                ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if ((ext == ".xls") || (ext == ".xlsx"))
                {
                    if (ext == ".xls")
                        SourceConstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
                    else if (ext == ".xlsx")
                        SourceConstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;";

                    using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(SourceConstr))
                    {
                        con.Open();
                        System.Data.OleDb.OleDbCommand com = new System.Data.OleDb.OleDbCommand("Select * from [Sheet1$]", con);
                        OleDbDataAdapter oda = new OleDbDataAdapter(com);
                        oda.Fill(dtTemp);

                        string[] arrColumns = new string[dtTemp.Columns.Count];
                        arrColumns = "Company Name,Address,Mobile,Phone No,Email ID,Vat No".Split(',');

                        for (int i = 0; i < arrColumns.Length; i++)
                        {
                            if (dtTemp.Columns[i].ColumnName != arrColumns[i])
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('" + dtTemp.Columns[i].ColumnName + " ','is unknown Column.')", true);
                                flg = false;
                                break;
                            }
                        }
                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            string mobile = dtTemp.Rows[i]["Mobile"].ToString().Trim();
                            if (mobile != "" && !Regex.IsMatch(mobile, "^[0-9.]+$", RegexOptions.Compiled))
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('In line no. " + Convert.ToInt16(i + 1) + " Mobile No contains characte(s). Please remove the character(s)!','')", true);
                                flg = false;
                                break;
                            }
                        }

                        if (flg)
                        {
                            rptCustomerExcel.DataSource = dtTemp;
                            rptCustomerExcel.DataBind();
                            rptCustomerExcel.Visible = true;
                            ViewState["ExcelData"] = dtTemp;
                            btnUpload.Visible = false;
                            btnDownload.Visible = false;
                            btnConfirm.Visible = true;
                            tbl.Visible = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            custObj = new CustomerClass();
            DataTable dtExcel = (DataTable)ViewState["ExcelData"];
            if (dtExcel.Rows.Count > 0)
            {
                int insert = custObj.SaveCustomerByExcel(dtExcel);
                if (insert > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('" + insert + " ','Customers added Successfully.')", true);
                    btnConfirm.Visible = false;
                    btnUpload.Visible = true;
                    btnDownload.Visible = true;
                    tbl.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpload.Text = "Upload";
            btnConfirm.Visible = false;
            tbl.Visible = false;
            ViewState["ExcelData"] = string.Empty;
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Windows/downloads/Customer Information Format.xlsx");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}