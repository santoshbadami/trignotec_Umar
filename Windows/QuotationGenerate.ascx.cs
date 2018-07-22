using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_QuotationGenerate : System.Web.UI.UserControl
{
    CustomerClass custObj;
    QuotationClass quotObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtQuotationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                BindCustomer();
                GetNextQuotationNo();
                BindDescription();

            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
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

    private void GetNextQuotationNo()
    {
        quotObj = new QuotationClass();
        txtQuotationNo.Text = quotObj.GetNextQuotationNo();
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

}