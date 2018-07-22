using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_InvoiceView : System.Web.UI.UserControl
{
    InvoiceClass invObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindAllInvoice();
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void BindAllInvoice()
    {
        invObj = new InvoiceClass();
        DataTable dtInv = invObj.GetAllInvoiceDetails();
        rptInvoiceView.DataSource = dtInv.Rows.Count > 0 ? dtInv : null;
        rptInvoiceView.DataBind();
    }

    protected void lblView_Click(object sender, EventArgs e)
    {
        try
        {
            invObj = new InvoiceClass();
            invObj.invId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Windows/Default.aspx?uc=12&invId=" + invObj.invId);
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
            invObj = new InvoiceClass();
            invObj.invId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            if (invObj.DeleteInvoiceByInvId())
            {
                BindAllInvoice();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Invoice Deleted Successfully.','')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to Delete Invoice.','')", true);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void lbEdit_Click(object sender, EventArgs e)
    {
        try
        {
            invObj = new InvoiceClass();
            invObj.invId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Windows/Default.aspx?uc=11&iid=" + invObj.invId);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}