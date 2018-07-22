using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_InvoiceGenerate : System.Web.UI.UserControl
{
    InvoiceClass invObj;
    CustomerClass custObj;
    QuotationClass quotObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindQuotationNos();
                BindCustomer();
                BindDescription();
                GetNextInvoiceNo();
                GetOpenInvoiceNos();
                txtInvoiceDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void GetNextInvoiceNo()
    {
        invObj = new InvoiceClass();
        txtInvoiceNo.Text = invObj.GetNextInvoiceNo();
    }

    public void GetOpenInvoiceNos()
    {
        invObj = new InvoiceClass();
        DataTable dtInv = invObj.GetOpenInvoiceNos();
        if (dtInv.Rows.Count > 0)
        {
            ddlPendingInvoiceNumber.DataSource = dtInv;
            ddlPendingInvoiceNumber.DataValueField = "invIdUniqueNo";
            ddlPendingInvoiceNumber.DataTextField = "invoiceNo";
            ddlPendingInvoiceNumber.DataBind();
            ddlPendingInvoiceNumber.Items.Insert(0, new ListItem("-- Select Invoice No --", "0"));
        }
        else
            ddlPendingInvoiceNumber.Items.Insert(0, new ListItem("-- No Pending Invoice --", "0"));
        
    }

    private void BindQuotationNos()
    {
        invObj = new InvoiceClass();
        DataTable dtQuot = invObj.GetQuotationNoForInvoice();
        if (dtQuot.Rows.Count > 0)
        {
            ddlQuotationNumber.DataSource = dtQuot;
            ddlQuotationNumber.DataValueField = "quotNo";
            ddlQuotationNumber.DataTextField = "QquotNo";
            ddlQuotationNumber.DataBind();
        }
        ddlQuotationNumber.Items.Insert(0, new ListItem("-- Quotation No --", "0"));
    }

    private void BindCustomer()
    {
        custObj = new CustomerClass();
        custObj.custId = "%";
        DataTable dtCust = custObj.GetCustomerMasterByCustId();
        if (dtCust.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtCust;
            ddlCustomer.DataValueField = "custId";
            ddlCustomer.DataTextField = "custName";
            ddlCustomer.DataBind();
        }
        ddlCustomer.Items.Insert(0, new ListItem("-- Select Customer --", "0"));
    }

    private void BindDescription()
    {
        quotObj = new QuotationClass();
        DataTable dtProd = quotObj.GetproductDetailsForQuoAndIn();
        if (dtProd.Rows.Count > 0)
        {
            ddlDescription.DataSource = dtProd;
            ddlDescription.DataValueField = "prodId";
            ddlDescription.DataTextField = "description";
            ddlDescription.DataBind();
            ddlDescription.Items.Insert(0, new ListItem("-- Select Description --", "0"));
        }
    }
}