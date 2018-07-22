using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Windows_InvoicePrint : System.Web.UI.UserControl
{
    InvoiceClass invObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["invId"]))
                {
                    invObj = new InvoiceClass();
                    invObj.invId = Convert.ToInt32(Request.QueryString["invId"]);
                    DataSet dsInv = invObj.GetInvoiceDetailsByInvId();
                    if (dsInv.Tables[0].Rows.Count > 0)
                    {
                        lblCustomerName.Text = dsInv.Tables[0].Rows[0]["custName"].ToString();
                        lblInvoiceNo.Text = dsInv.Tables[0].Rows[0]["invoiceNo"].ToString();
                        lblInvoiceDate.Text = Convert.ToDateTime(dsInv.Tables[0].Rows[0]["invoiceDate"].ToString()).ToString("dd-MM-yyyy");

                        rptInvoiceDetails.DataSource = dsInv.Tables[1];
                        rptInvoiceDetails.DataBind();

                        lblVat1.Text = lblVat2.Text = dsInv.Tables[2].Rows[0]["vatPer"].ToString();
                        lblAmtExVatSR.Text = dsInv.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[0];
                        lblAmtExVatH.Text = dsInv.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[1];
                        lblVatAmtSR.Text = dsInv.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[0];
                        lblVatAmtH.Text = dsInv.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[1];
                        lblTotalInWords.Text = ConvertNumbertoWords(Convert.ToInt32(dsInv.Tables[2].Rows[0]["totalInTax"]));
                        lblAmtInVatSR.Text = dsInv.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[0];
                        lblAmtInVatH.Text = dsInv.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[1];
                        lblTermsAndConditions.Text = dsInv.Tables[2].Rows[0]["termsAndContions"].ToString();

                        btnEdit.CommandArgument = Request.QueryString["invId"];
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    public string ConvertNumbertoWords(int number)
    {
        if (number == 0) return "Zero";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        //we can add if conditions as 
        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " Lakh ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " Hundred ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "And ";
            var unitsMap = new[]   
        {  
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"  
        };
            var tensMap = new[]   
        {  
            "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Senenty", "Eighty", "Ninety"  
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            invObj = new InvoiceClass();
            invObj.invId = Convert.ToInt32(btnEdit.CommandArgument);
            Response.Redirect("~/Windows/Default.aspx?uc=11&iid=" + invObj.invId);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}