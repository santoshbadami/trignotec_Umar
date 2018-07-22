using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for QuotationClass
/// </summary>
public class QuotationClass
{
    public int quotId { get; set; }
    public string quotNo { get; set; }
    public string quotDate { get; set; }
    public int custId { get; set; }
    public string custName { get; set; }

    public string qdId { get; set; }
    public int prodId { get; set; }
    public string prodDescription { get; set; }
    public string qty { get; set; }
    public string prodPrice { get; set; }
    public string totalPrice { get; set; }

    public string totalExVat { get; set; }
    public string vatPer { get; set; }
    public string vatAmt { get; set; }
    public string totalInTax { get; set; }
    public string termsAndConditions { get; set; }

    public string errMsg = string.Empty;
    DataAccessLayer dalObj = null; // DAL - Data Access Layer instance

    public QuotationClass()
    {
        dalObj = new DataAccessLayer();
    }

    public string GetNextQuotationNo()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "SELECT fn_GetNextQuotationNo();";
            return dalObj.getSelectDataByInlineQuery(cmd, out errMsg).Rows[0][0].ToString();
        }
    }

    //getproductDetailsForQuoAndIn
    public DataTable GetproductDetailsForQuoAndIn()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getproductDetailsForQuoAndIn";
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    public DataTable SaveQuotationMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveQuotationMaster";
            cmd.Parameters.Add("_quotNo", quotNo);
            cmd.Parameters.Add("_quotDate", quotDate);
            cmd.Parameters.Add("_custId", custId);
            cmd.Parameters.Add("_custName", custName);
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //saveQuotationDetails
    public bool SaveQuotationDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveQuotationDetails";
            cmd.Parameters.Add("_quotId", quotId);
            cmd.Parameters.Add("_prodId", prodId);
            cmd.Parameters.Add("_prodDescription", prodDescription);
            cmd.Parameters.Add("_prodPrice", prodPrice);
            cmd.Parameters.Add("_qty", qty);
            cmd.Parameters.Add("_totalPrice", totalPrice);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //savequotationPaymentDetails
    public bool SavequotationPaymentDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "savequotationPaymentDetails";
            cmd.Parameters.Add("_quotId", quotId);
            cmd.Parameters.Add("_totalExVat", totalExVat);
            cmd.Parameters.Add("_vatPer", vatPer);
            cmd.Parameters.Add("_vatAmt", vatAmt);
            cmd.Parameters.Add("_totalInTax", totalInTax);
            cmd.Parameters.Add("_termsAndContions", termsAndConditions);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //getQuotationDetailsByQuotId
    public DataSet GetQuotationDetailsByQuotId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getQuotationDetailsByQuotId";
            cmd.Parameters.Add("_quotID", quotId);
            return dalObj.getSelectDataSet(cmd, out errMsg);
        }
    }

    //getAllQuotationDetails
    public DataTable GetAllQuotationDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getAllQuotationDetails";
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //validateQuotationNo
    public bool ValidateQuotationNo()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "validateQuotationNo";
            cmd.Parameters.Add("_quotNo", quotNo);
            cmd.Parameters.Add("_quotId", quotId);
            return dalObj.getSelectData(cmd, out errMsg).Rows.Count > 0 ? true : false;
        }
    }

    //updateQuotationMaster
    public bool UpdateQuotationMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updateQuotationMaster";
            cmd.Parameters.Add("_quotId", quotId);
            cmd.Parameters.Add("_quotNo", quotNo);
            cmd.Parameters.Add("_quotDate", quotDate);
            cmd.Parameters.Add("_custId", custId);
            cmd.Parameters.Add("_custName", custName);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //quotationDetailsDeleteByQuotId
    public bool QuotationDetailsDeleteByQuotId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "quotationDetailsDeleteByQuotId";
            cmd.Parameters.Add("_quotId", quotId);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //updatequotationPaymentDetails
    public bool UpdatequotationPaymentDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updatequotationPaymentDetails";
            cmd.Parameters.Add("_quotId", quotId);
            cmd.Parameters.Add("_totalExVat", totalExVat);
            cmd.Parameters.Add("_vatPer", vatPer);
            cmd.Parameters.Add("_vatAmt", vatAmt);
            cmd.Parameters.Add("_totalInTax", totalInTax);
            cmd.Parameters.Add("_termsAndContions", termsAndConditions);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }
}