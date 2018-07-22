using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    QuotationClass quotObj;
    InvoiceClass invObj;

    public WebService()
    {

    }

    public class quotationArray
    {
        public int quotId { get; set; }
        public int custId { get; set; }
        public string custName { get; set; }
        public string quotationNo { get; set; }
        public string quotaionDate { get; set; }
        public string totExVat { get; set; }
        public string vatPer { get; set; }
        public string vatAmt { get; set; }
        public string totInVat { get; set; }
        public string termsAndConditions { get; set; }
        public List<quotationDetailsArray> quotationDetailsArray { get; set; }
    }

    public class quotationDetailsArray
    {
        public int prodId { get; set; }
        public string product { get; set; }
        public string qty { get; set; }
        public string unitPrice { get; set; }
        public string totalPrice { get; set; }
    }

    [WebMethod]
    public int SaveQuotation(string _quotation)
    {
        quotObj = new QuotationClass();
        quotationArray qa = JsonConvert.DeserializeObject<quotationArray>(_quotation);
        quotObj.quotNo = qa.quotationNo.Replace("Q", "");
        if (!ValidateQuotationNo(qa.quotationNo.Replace("Q", ""), "0"))
        {
            quotObj.quotNo = qa.quotationNo.Replace("Q", "");
            quotObj.quotDate = "2018-08-23";
            quotObj.custId = qa.custId;
            quotObj.custName = qa.custName;
            quotObj.quotId = Convert.ToInt32(quotObj.SaveQuotationMaster().Rows[0][0]);
            if (quotObj.quotId > 0)
            {
                for (int i = 0; i < qa.quotationDetailsArray.Count; i++)
                {
                    quotObj.prodId = qa.quotationDetailsArray[i].prodId;
                    quotObj.prodDescription = qa.quotationDetailsArray[i].product;
                    quotObj.qty = qa.quotationDetailsArray[i].qty;
                    quotObj.prodPrice = qa.quotationDetailsArray[i].unitPrice;
                    quotObj.totalPrice = qa.quotationDetailsArray[i].totalPrice;
                    quotObj.SaveQuotationDetails();
                }
                quotObj.totalExVat = qa.totExVat;
                quotObj.vatPer = qa.vatPer;
                quotObj.vatAmt = qa.vatAmt;
                quotObj.totalInTax = qa.totInVat;
                quotObj.termsAndConditions = qa.termsAndConditions;
                quotObj.SavequotationPaymentDetails();

                return quotObj.quotId;
            }
            else
                return 0;
        }
        else
            return 0;
    }

    //[WebMethod]
    //public string SaveProductWhileAddingQuoAndIn(string _product, string _type, string _unitPrice)
    //{
    //    prodObj = new ProductClass();
    //    prodObj.description = _product;
    //    prodObj.unitPrice = _unitPrice;
    //    prodObj.typ = _type;
    //    prodObj.prodId = prodObj.SaveProductWhileAddingQuoAndIn();
    //    if (!string.IsNullOrEmpty(prodObj.prodId))
    //        return prodObj.prodId;
    //    else
    //        return "0";
    //}

    //EditQuotation

    [WebMethod]
    public string EditQuotation(string _qid)
    {
        quotObj = new QuotationClass();
        quotObj.quotId = Convert.ToInt32(_qid);
        DataSet dsQuot = quotObj.GetQuotationDetailsByQuotId();
        if (dsQuot.Tables[0].Rows.Count > 0)
        {
            dsQuot.Tables[1].Columns["prodDescription"].ColumnName = "product";
            dsQuot.Tables[1].Columns["prodPrice"].ColumnName = "unitPrice";
            dsQuot.Tables[1].Columns.Add("arrId");
            string json = JsonConvert.SerializeObject(dsQuot, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
        else
            return "";
    }

    [WebMethod]
    public bool ValidateQuotationNo(string _quotationNo, string _quotId)
    {
        if (!string.IsNullOrEmpty(_quotationNo))
        {
            quotObj = new QuotationClass();
            quotObj.quotNo = _quotationNo;
            quotObj.quotId = Convert.ToInt32(_quotId);
            if (quotObj.ValidateQuotationNo())
                return true;
            else
                return false;
        }
        else
            return false;
    }

    [WebMethod]
    public int UpdateQuotation(string _quotation)
    {
        quotObj = new QuotationClass();
        quotationArray qa = JsonConvert.DeserializeObject<quotationArray>(_quotation);
        if (!ValidateQuotationNo(qa.quotationNo.Replace("Q", ""), qa.quotId.ToString()))
        {
            quotObj.quotId = qa.quotId;
            quotObj.quotNo = qa.quotationNo.Replace("Q", "");
            quotObj.quotDate = Convert.ToDateTime(qa.quotaionDate).ToString("yyyy-MM-dd");
            quotObj.custId = qa.custId;
            quotObj.custName = qa.custName;
            if (quotObj.UpdateQuotationMaster())
            {
                if (quotObj.QuotationDetailsDeleteByQuotId())
                {
                    for (int i = 0; i < qa.quotationDetailsArray.Count; i++)
                    {
                        quotObj.prodId = qa.quotationDetailsArray[i].prodId;
                        quotObj.prodDescription = qa.quotationDetailsArray[i].product;
                        quotObj.qty = qa.quotationDetailsArray[i].qty;
                        quotObj.prodPrice = qa.quotationDetailsArray[i].unitPrice;
                        quotObj.totalPrice = qa.quotationDetailsArray[i].totalPrice;
                        quotObj.SaveQuotationDetails();
                    }
                }
                quotObj.totalExVat = qa.totExVat;
                quotObj.vatPer = qa.vatPer;
                quotObj.vatAmt = qa.vatAmt;
                quotObj.totalInTax = qa.totInVat;
                quotObj.termsAndConditions = qa.termsAndConditions;
                quotObj.UpdatequotationPaymentDetails();

                return quotObj.quotId;
            }
            else
                return 0;
        }
        else
            return 0;
    }

    public class invoiceArray
    {
        public int quotId { get; set; }
        public int invId { get; set; }
        public int custId { get; set; }
        public string custName { get; set; }
        public string custVat { get; set; }
        public string invoiceNo { get; set; }
        public string invoiceDate { get; set; }
        public string amount { get; set; }
        public string invUniqueNo { get; set; }
        public string totExVat { get; set; }
        public string vatPer { get; set; }
        public string vatAmt { get; set; }
        public string totInVat { get; set; }
        public string termsAndConditions { get; set; }
        public List<invoiceDetailsArray> invoiceDetailsArray { get; set; }
    }

    public class invoiceDetailsArray
    {
        public int prodId { get; set; }
        public string product { get; set; }
        public string qty { get; set; }
        public string unitPrice { get; set; }
        public string totalPrice { get; set; }
    }

    [WebMethod]
    public int SaveInvoice(string _invoice)
    {
        invObj = new InvoiceClass();
        invoiceArray inv = JsonConvert.DeserializeObject<invoiceArray>(_invoice);
        if (!ValidateInvoiceNo(inv.invoiceNo, inv.invId.ToString()))
        {
            invObj.quotId = inv.quotId;
            invObj.custId = inv.custId;
            invObj.custName = inv.custName;
            invObj.custVat = inv.custVat;
            invObj.invoiceNo = inv.invoiceNo;
            invObj.invoiceDate = Convert.ToDateTime(inv.invoiceDate).ToString("yyyy-MM-dd");
            invObj.amount = inv.amount;
            invObj.invUniqueNo = Convert.ToInt32(inv.invUniqueNo);
            invObj.invId = Convert.ToInt32(invObj.SaveInvoiceMaster().Rows[0][0]);
            if (invObj.invId > 0)
            {
                for (int i = 0; i < inv.invoiceDetailsArray.Count; i++)
                {
                    invObj.prodId = inv.invoiceDetailsArray[i].prodId;
                    invObj.prodDescription = inv.invoiceDetailsArray[i].product;
                    invObj.qty = inv.invoiceDetailsArray[i].qty;
                    invObj.prodPrice = inv.invoiceDetailsArray[i].unitPrice;
                    invObj.totalPrice = inv.invoiceDetailsArray[i].totalPrice;
                    invObj.SaveInvoiceDetails();
                }

                invObj.totalExVat = inv.totExVat;
                invObj.vatPer = inv.vatPer;
                invObj.vatAmt = inv.vatAmt;
                invObj.totalInTax = inv.totInVat;
                invObj.termsAndConditions = inv.termsAndConditions;
                invObj.SaveInvoicePaymentDetails();

                return invObj.invId;
            }
            else
                return 0;
        }
        else
            return 0;
    }

    [WebMethod]
    public string EditInvoice(string _invId)
    {
        invObj = new InvoiceClass();
        invObj.invId = Convert.ToInt32(_invId);
        DataSet dsInv = invObj.GetInvoiceDetailsByInvId();
        if (dsInv.Tables[0].Rows.Count > 0)
        {
            dsInv.Tables[1].Columns["prodDescription"].ColumnName = "product";
            dsInv.Tables[1].Columns["prodPrice"].ColumnName = "unitPrice";
            dsInv.Tables[1].Columns.Add("arrId");
            string json = JsonConvert.SerializeObject(dsInv, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
        else
            return "";
    }

    [WebMethod]
    public bool ValidateInvoiceNo(string _invoiceNo, string _invId)
    {
        if (!string.IsNullOrEmpty(_invoiceNo))
        {
            invObj = new InvoiceClass();
            invObj.invoiceNo = _invoiceNo;
            invObj.invId = Convert.ToInt32(_invId);
            if (invObj.ValidateInvoiceNo())
                return true;
            else
                return false;
        }
        else
            return false;
    }

    [WebMethod]
    public int UpdateInvoice(string _invoice)
    {
        invObj = new InvoiceClass();
        invoiceArray inv = JsonConvert.DeserializeObject<invoiceArray>(_invoice);
        if (!ValidateInvoiceNo(inv.invoiceNo, inv.invId.ToString()))
        {
            invObj.invId = inv.invId;
            invObj.custId = inv.custId;
            invObj.custName = inv.custName;
            invObj.invoiceNo = inv.invoiceNo;
            invObj.invoiceDate = Convert.ToDateTime(inv.invoiceDate).ToString("yyyy-MM-dd");
            invObj.amount = inv.amount;
            invObj.invUniqueNo = Convert.ToInt32(inv.invUniqueNo);
            if (invObj.UpdateInvoiceMaster())
            {
                if (invObj.InvoiceDetailsDeleteByInvId())
                {
                    for (int i = 0; i < inv.invoiceDetailsArray.Count; i++)
                    {
                        invObj.prodId = inv.invoiceDetailsArray[i].prodId;
                        invObj.prodDescription = inv.invoiceDetailsArray[i].product;
                        invObj.qty = inv.invoiceDetailsArray[i].qty;
                        invObj.prodPrice = inv.invoiceDetailsArray[i].unitPrice;
                        invObj.totalPrice = inv.invoiceDetailsArray[i].totalPrice;
                        invObj.SaveInvoiceDetails();
                    }
                }
                invObj.totalExVat = inv.totExVat;
                invObj.vatPer = inv.vatPer;
                invObj.vatAmt = inv.vatAmt;
                invObj.totalInTax = inv.totInVat;
                invObj.termsAndConditions = inv.termsAndConditions;
                invObj.UpdateinvoicePaymentDetails();

                return invObj.invId;
            }
            else
                return 0;
        }
        else
            return 0;
    }
}
