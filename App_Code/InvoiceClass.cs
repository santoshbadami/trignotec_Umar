using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for InvoiceClass
/// </summary>
public class InvoiceClass
{
    public int invId { get; set; }
    public int invUniqueNo { get; set; }
    public string invoiceNo { get; set; }
    public string invoiceDate { get; set; }
    public int custId { get; set; }
    public string custName { get; set; }
    public string custVat { get; set; }
    public int quotId { get; set; }
    public string amount { get; set; }

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

    public InvoiceClass()
    {
        dalObj = new DataAccessLayer();
    }

    //getQuotationNoForInvoice
    public DataTable GetQuotationNoForInvoice()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getQuotationNoForInvoice";
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //GetNextInvoiceNo
    public string GetNextInvoiceNo()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "SELECT fn_GetNextInvoiceNo();";
            return dalObj.getSelectDataByInlineQuery(cmd, out errMsg).Rows[0][0].ToString();
        }
    }

    //getOpenInvoiceNos
    public DataTable GetOpenInvoiceNos()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getOpenInvoiceNos";
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //saveInvoiceMaster
    public DataTable SaveInvoiceMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveInvoiceMaster";
            cmd.Parameters.Add("_quotId", quotId);
            cmd.Parameters.Add("_invoiceNo", invoiceNo);
            cmd.Parameters.Add("_invoiceDate", invoiceDate);
            cmd.Parameters.Add("_custId", custId);
            cmd.Parameters.Add("_custName", custName);
            cmd.Parameters.Add("_custVat", custVat);
            cmd.Parameters.Add("_amount", amount);
            cmd.Parameters.Add("_invUniqueNo", invUniqueNo);
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //saveInvoiceDetails
    public bool SaveInvoiceDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveInvoiceDetails";
            cmd.Parameters.Add("_invId", invId);
            cmd.Parameters.Add("_prodId", prodId);
            cmd.Parameters.Add("_prodDescription", prodDescription);
            cmd.Parameters.Add("_prodPrice", prodPrice);
            cmd.Parameters.Add("_qty", qty);
            cmd.Parameters.Add("_totalPrice", totalPrice);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //saveInvoicePaymentDetails
    public bool SaveInvoicePaymentDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveInvoicePaymentDetails";
            cmd.Parameters.Add("_invId", invId);
            cmd.Parameters.Add("_totalExVat", totalExVat);
            cmd.Parameters.Add("_vatPer", vatPer);
            cmd.Parameters.Add("_vatAmt", vatAmt);
            cmd.Parameters.Add("_totalInTax", totalInTax);
            cmd.Parameters.Add("_termsAndContions", termsAndConditions);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //getInvoiceDetailsByInvId
    public DataSet GetInvoiceDetailsByInvId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getInvoiceDetailsByInvId";
            cmd.Parameters.Add("_invId", invId);
            return dalObj.getSelectDataSet(cmd, out errMsg);
        }
    }

    //getAllInvoiceDetails
    public DataTable GetAllInvoiceDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getAllInvoiceDetails";
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //validateInvoiceNo
    public bool ValidateInvoiceNo()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "validateInvoiceNo";
            cmd.Parameters.Add("_invoiceNo", invoiceNo);
            cmd.Parameters.Add("_invId", invId);
            return dalObj.getSelectData(cmd, out errMsg).Rows.Count > 0 ? true : false;
        }
    }

    //deleteInvoiceByInvId
    public bool DeleteInvoiceByInvId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "deleteInvoiceByInvId";
            cmd.Parameters.Add("_invId", invId);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //updateInvoiceMaster
    public bool UpdateInvoiceMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updateInvoiceMaster";
            cmd.Parameters.Add("_invId", invId);
            cmd.Parameters.Add("_invoiceNo", invoiceNo);
            cmd.Parameters.Add("_invoiceDate", invoiceDate);
            cmd.Parameters.Add("_custId", custId);
            cmd.Parameters.Add("_custName", custName);
            cmd.Parameters.Add("_amount", amount);
            cmd.Parameters.Add("_uniqueNo", invUniqueNo);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //invoiceDetailsDeleteByInvId
    public bool InvoiceDetailsDeleteByInvId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "invoiceDetailsDeleteByInvId";
            cmd.Parameters.Add("_invId", invId);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //updateinvoicePaymentDetails
    public bool UpdateinvoicePaymentDetails()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updateinvoicePaymentDetails";
            cmd.Parameters.Add("_invId", invId);
            cmd.Parameters.Add("_totalExVat", totalExVat);
            cmd.Parameters.Add("_vatPer", vatPer);
            cmd.Parameters.Add("_vatAmt", vatAmt);
            cmd.Parameters.Add("_totalInTax", totalInTax);
            cmd.Parameters.Add("_termsAndContions", termsAndConditions);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }
}