using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_CustomerAdd : System.Web.UI.UserControl
{
    CustomerClass custObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                if (!string.IsNullOrEmpty(Request.QueryString["custId"]))
                {
                    EditCustomer();
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                custObj = new CustomerClass();
                custObj.custName = txtCompanyName.Text.Trim();
                custObj.address = txtAddress.Text.Trim();
                custObj.mobile = txtMobile.Text.Trim();
                custObj.phone = txtPhoneNo.Text.Trim();
                custObj.emailId = txtEmailID.Text.Trim();
                custObj.vatNo = txtVatNo.Text.Trim();
                custObj.typ = "Manual";
                if (string.IsNullOrEmpty(btnSave.CommandArgument))
                {
                    if (custObj.SaveCustomerMaster())
                    {
                        ClearControls();
                        Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Customer Added Successfully.','')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to add Customer.','')", true);
                    }
                }
                else
                {
                    custObj.custId = btnSave.CommandArgument;
                    if (custObj.UpdateCustomerMaster())
                    {
                        ClearControls();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Customer Updated Successfully.','')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to Update Customer.','')", true);
                    }
                }
            }
            else
            {
                ClearControls();
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
            ClearControls();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void ClearControls()
    {
        txtCompanyName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtPhoneNo.Text = string.Empty;
        txtEmailID.Text = string.Empty;
        txtVatNo.Text = string.Empty;
        btnSave.CommandArgument = string.Empty;
        btnSave.Text = "Save";
    }

    private void EditCustomer()
    {
        custObj = new CustomerClass();
        custObj.custId = Request.QueryString["custId"];
        DataTable dtCust = custObj.GetCustomerMasterByCustId();
        if (dtCust.Rows.Count.Equals(1))
        {
            btnSave.CommandArgument = custObj.custId;
            txtCompanyName.Text = dtCust.Rows[0]["custName"].ToString();
            txtAddress.Text = dtCust.Rows[0]["address"].ToString();
            txtMobile.Text = dtCust.Rows[0]["mobile"].ToString();
            txtPhoneNo.Text = dtCust.Rows[0]["phone"].ToString();
            txtEmailID.Text = dtCust.Rows[0]["emailId"].ToString();
            txtVatNo.Text = dtCust.Rows[0]["vatNo"].ToString();
            btnSave.Text = "Update";
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        ViewState["update"] = Session["update"];
    }
}