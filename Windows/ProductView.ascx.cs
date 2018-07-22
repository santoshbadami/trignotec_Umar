using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_ProductView : System.Web.UI.UserControl
{
    ProductClass prodObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LoadProducts();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void LoadProducts()
    {
        prodObj = new ProductClass();
        prodObj.prodId = "%";
        DataTable dtProd = prodObj.GetProductMasterByProdId();
        rptProduct.DataSource = dtProd.Rows.Count > 0 ? dtProd : null;
        rptProduct.DataBind();
    }

    protected void lbEdit_Click(object sender, EventArgs e)
    {
        try
        {
            prodObj = new ProductClass();
            prodObj.prodId = ((LinkButton)sender).CommandArgument;
            if (!string.IsNullOrEmpty(prodObj.prodId))
                Response.Redirect("~/Windows/Default.aspx?uc=5&prodId=" + prodObj.prodId);
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
            prodObj = new ProductClass();
            prodObj.prodId = ((LinkButton)sender).CommandArgument;
            if (prodObj.DeleteProductMasterByProdId())
            {
                LoadProducts();
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