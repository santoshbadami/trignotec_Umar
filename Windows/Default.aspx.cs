using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Windows_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserControl dashboard = (UserControl)LoadControl("~/Windows/Dashboard.ascx");

        UserControl customerAdd = (UserControl)LoadControl("~/Windows/CustomerAdd.ascx");
        UserControl customerAddByExcel = (UserControl)LoadControl("~/Windows/CustomerAddByExcel.ascx");
        UserControl customerView = (UserControl)LoadControl("~/Windows/CustomerView.ascx");

        UserControl productAdd = (UserControl)LoadControl("~/Windows/ProductAdd.ascx");
        UserControl productAddByExcel = (UserControl)LoadControl("~/Windows/ProductAddByExcel.ascx");
        UserControl productView = (UserControl)LoadControl("~/Windows/ProductView.ascx");

        UserControl quotationGenerate = (UserControl)LoadControl("~/Windows/QuotationGenerate.ascx");
        UserControl quotationPrint = (UserControl)LoadControl("~/Windows/QuotationPrint.ascx");
        UserControl quotaionView = (UserControl)LoadControl("~/Windows/QuotaionView.ascx");

        UserControl invoiceGenerate = (UserControl)LoadControl("~/Windows/InvoiceGenerate.ascx");
        UserControl invoicePrint = (UserControl)LoadControl("~/Windows/InvoicePrint.ascx");
        UserControl invoiceView = (UserControl)LoadControl("~/Windows/InvoiceView.ascx");

        pnlControls.Controls.Clear();

        try
        {
            if (Request.QueryString["uc"].ToString().Equals("1"))
            {
                pnlControls.Controls.Add(dashboard);
            }
            else if (Request.QueryString["uc"].ToString().Equals("2"))
            {
                pnlControls.Controls.Add(customerAdd);
            }
            else if (Request.QueryString["uc"].ToString().Equals("3"))
            {
                pnlControls.Controls.Add(customerAddByExcel);
            }
            else if (Request.QueryString["uc"].ToString().Equals("4"))
            {
                pnlControls.Controls.Add(customerView);
            }
            else if (Request.QueryString["uc"].ToString().Equals("5"))
            {
                pnlControls.Controls.Add(productAdd);
            }
            else if (Request.QueryString["uc"].ToString().Equals("6"))
            {
                pnlControls.Controls.Add(productAddByExcel);
            }
            else if (Request.QueryString["uc"].ToString().Equals("7"))
            {
                pnlControls.Controls.Add(productView);
            }
            else if (Request.QueryString["uc"].ToString().Equals("8"))
            {
                pnlControls.Controls.Add(quotationGenerate);
            }
            else if (Request.QueryString["uc"].ToString().Equals("9"))
            {
                pnlControls.Controls.Add(quotationPrint);
            }
            else if (Request.QueryString["uc"].ToString().Equals("10"))
            {
                pnlControls.Controls.Add(quotaionView);
            }
            else if (Request.QueryString["uc"].ToString().Equals("11"))
            {
                pnlControls.Controls.Add(invoiceGenerate);
            }
            else if (Request.QueryString["uc"].ToString().Equals("12"))
            {
                pnlControls.Controls.Add(invoicePrint);
            }
            else if (Request.QueryString["uc"].ToString().Equals("13"))
            {
                pnlControls.Controls.Add(invoiceView);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}