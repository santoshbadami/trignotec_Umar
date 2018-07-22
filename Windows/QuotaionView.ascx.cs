using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_QuotaionView : System.Web.UI.UserControl
{
    QuotationClass quotObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindQuotationDetails();
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void BindQuotationDetails()
    {
        quotObj = new QuotationClass();
        DataTable dtQout = quotObj.GetAllQuotationDetails();
        rptQuotationView.DataSource = dtQout.Rows.Count > 0 ? dtQout : null;
        rptQuotationView.DataBind();
    }

    protected void lblView_Click(object sender, EventArgs e)
    {
        try
        {
            quotObj = new QuotationClass();
            quotObj.quotId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Windows/Default.aspx?uc=9&qid=" + quotObj.quotId);
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

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}