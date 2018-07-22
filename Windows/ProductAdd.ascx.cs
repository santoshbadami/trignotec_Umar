using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_ProductAdd : System.Web.UI.UserControl
{
    ProductClass prodObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["prodId"]))
                {
                    EditProduct();
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
            prodObj = new ProductClass();
            prodObj.description = txtDescription.Text.Trim();
            prodObj.unitPrice = txtUnitPrice.Text.Trim();
            prodObj.typ = "Manual";
            if (string.IsNullOrEmpty(btnSave.CommandArgument))
            {
                if (prodObj.SaveProductMaster())
                {
                    ClearControls();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Product Added Successfully.','')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to Product to add Customer.','')", true);
                }
            }
            else
            {
                prodObj.prodId = btnSave.CommandArgument;
                if (prodObj.UpdateProductMaster())
                {
                    ClearControls();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "successfull('Product Updated Successfully.','')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "failed('Failed to Product to Update Customer.','')", true);
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

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void EditProduct()
    {
        prodObj = new ProductClass();
        btnSave.CommandArgument = Request.QueryString["prodId"];
        prodObj.prodId = btnSave.CommandArgument;
        DataTable dtProd = prodObj.GetProductMasterByProdId();
        if (dtProd.Rows.Count == 1)
        {
            txtDescription.Text = dtProd.Rows[0]["description"].ToString();
            txtUnitPrice.Text = dtProd.Rows[0]["unitPrice"].ToString();
            btnSave.Text = "Update";
        }
    }

    private void ClearControls()
    {
        txtDescription.Text = string.Empty;
        txtUnitPrice.Text = string.Empty;
        btnSave.CommandArgument = string.Empty;
        btnSave.Text = "Save";
    }
}