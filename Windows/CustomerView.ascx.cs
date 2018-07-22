using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_CustomerView : System.Web.UI.UserControl
{
    CustomerClass custObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void LoadCustomers()
    {
        custObj = new CustomerClass();
        custObj.custId = "%";
        DataTable dtCust = custObj.GetCustomerMasterByCustId();
        rptCustomer.DataSource = dtCust.Rows.Count > 0 ? custObj.GetCustomerMasterByCustId() : null;
        rptCustomer.DataBind();
    }

    protected void lbEdit_Click(object sender, EventArgs e)
    {
        try
        {
            custObj = new CustomerClass();
            custObj.custId = ((LinkButton)sender).CommandArgument;
            if (!string.IsNullOrEmpty(custObj.custId))
                Response.Redirect("~/Windows/Default.aspx?uc=2&custId=" + custObj.custId);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        try
        {
            custObj = new CustomerClass();
            custObj.custId = ((LinkButton)sender).CommandArgument;
            if (custObj.DeleteCustomerMasterByCustId())
            {
                LoadCustomers();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Customer Deleted Successfully.','')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to Delete Customer.','')", true);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}