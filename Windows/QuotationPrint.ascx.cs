using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

public partial class Windows_QuotationPrint : System.Web.UI.UserControl
{
    QuotationClass quotObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["qid"]))
            {
                BindQuotation();
            }

            //string num = ArabicClass.ConvertNumeralsToArabic("123456");
        }
    }

    private void BindQuotation()
    {
        try
        {
            quotObj = new QuotationClass();
            quotObj.quotId = Convert.ToInt32(Request.QueryString["qid"]);
            DataSet dsQuot = quotObj.GetQuotationDetailsByQuotId();
            if (dsQuot.Tables[0].Rows.Count > 0)
            {
                lblCustomerName.Text = dsQuot.Tables[0].Rows[0]["custName"].ToString();
                lblQuotationNo.Text = "Q" + dsQuot.Tables[0].Rows[0]["quotNo"].ToString();
                lblQuotationDate.Text = Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"].ToString()).ToString("dd-MM-yyyy");

                rptQuotationDetails.DataSource = dsQuot.Tables[1];
                rptQuotationDetails.DataBind();

                lblVat1.Text = lblVat2.Text = dsQuot.Tables[2].Rows[0]["vatPer"].ToString();
                lblAmtExVatSR.Text = dsQuot.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[0];
                lblAmtExVatH.Text = dsQuot.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[1];
                lblVatAmtSR.Text = dsQuot.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[0];
                lblVatAmtH.Text = dsQuot.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[1];
                lblTotalInWords.Text = ConvertNumbertoWords(Convert.ToInt32(dsQuot.Tables[2].Rows[0]["totalInTax"]));
                lblAmtInVatSR.Text = dsQuot.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[0];
                lblAmtInVatH.Text = dsQuot.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[1];
                lblTermsAndConditions.Text = dsQuot.Tables[2].Rows[0]["termsAndContions"].ToString();
                //printQuotation(dsQuot);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    public void printQuotation(DataSet dsQuot)
    {
        Document doc = new Document(PageSize.A4, 20f, 15f, 25f, 5f);//left-right-top-bottom
        PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
        doc.Open();

        BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
        //BaseColor bc = new BaseColor(47, 70, 162);
        BaseColor bc = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#1584c5"));

        PdfPTable table = new PdfPTable(6);
        table.WidthPercentage = 100;
        float[] width = new float[] { 5f, 7f, 57f, 7f, 17f, 7f };
        table.SetWidths(width);

        PdfPCell cell;

        #region logo
        string url = Server.MapPath("~") + "/Windows/images/trignotec_logo.png";
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(url);
        img.ScaleToFit(200f, 50f);
        img.SetAbsolutePosition(30, 770);
        doc.Add(img);
        #endregion

        cell = new PdfPCell(new Phrase(" مؤ سسة علم المثلثات لتقية المعلومات ", new Font(bf, 20, Font.BOLD, bc)));
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.Colspan = 6;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("TRIGNO INFORMATION TECHNOLOGIES", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, Font.BOLD, bc)));
        cell.Border = 0;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.Colspan = 6;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("QUOTATION", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, Font.BOLD | Font.UNDERLINE, bc)));
        cell.Border = 0;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingTop = 30;
        cell.Colspan = 6;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("No.", FontFactory.GetFont("Arial", 12, Font.BOLD, bc)));
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("Q" + dsQuot.Tables[0].Rows[0]["quotNo"].ToString(), FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(219, 39, 123))));
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, bc)));
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("Date :", FontFactory.GetFont("Arial", 12, Font.BOLD, bc)));
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        string suffix = (Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day % 10 == 1 && Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day != 11) ? "st"
            : (Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day % 10 == 2 && Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day != 12) ? "nd"
            : (Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day % 10 == 3 && Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day != 13) ? "rd"
            : "th";
        string dat = Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Day + suffix + " " + Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).ToString("MMM") + ", " + Convert.ToDateTime(dsQuot.Tables[0].Rows[0]["quotDate"]).Year;

        cell = new PdfPCell(new Phrase(dat, FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, Font.BOLD | Font.UNDERLINE, bc)));
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase("التاريج :", new Font(bf, 12, Font.NORMAL, bc)));
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("Ms. / Mr.:", FontFactory.GetFont("Arial", 12, Font.BOLD, bc)));
        cell.Border = 0;
        cell.Colspan = 2;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[0].Rows[0]["custName"].ToString(), new Font(bf, 12, Font.BOLD)));
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthBottom = 1;
        cell.BorderColorBottom = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingTop = 15;
        cell.PaddingBottom = 5;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(" المطلوب من السيد/ السادة", new Font(bf, 13, Font.NORMAL, bc)));
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingTop = 15;
        cell.PaddingLeft = 15;
        cell.Colspan = 3;
        table.AddCell(cell);

        PdfPTable table1 = new PdfPTable(7);
        table1.WidthPercentage = 100;
        float[] width1 = new float[] { 8f, 40f, 8f, 10f, 10f, 10f, 10f };
        table1.SetWidths(width1);

        cell = new PdfPCell(new Phrase("Empty", FontFactory.GetFont("Arial", 2, Font.BOLD, BaseColor.WHITE)));
        cell.Border = 0;
        cell.Colspan = 7;
        table1.AddCell(cell);

        Phrase pr = new Phrase();
        pr.Add(new Chunk("رقم البند", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("\n.", new Font(bf, 4, Font.BOLD, BaseColor.WHITE)));
        pr.Add(new Chunk("\nItem\n.No ", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthTop = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.Rowspan = 2;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingLeft = 5;
        cell.PaddingTop = 10;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("البيان", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("\n.", new Font(bf, 4, Font.BOLD, BaseColor.WHITE)));
        pr.Add(new Chunk("\nDescription", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthTop = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.Rowspan = 2;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingTop = 10;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("العدد", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("\n.", new Font(bf, 4, Font.BOLD, BaseColor.WHITE)));
        pr.Add(new Chunk("\n.Qty", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthTop = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.Rowspan = 2;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingTop = 10;
        cell.PaddingLeft = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("سعر الوحدة", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("\n.", new Font(bf, 4, Font.BOLD, BaseColor.WHITE)));
        pr.Add(new Chunk("\nUnit Price", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthTop = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.Colspan = 2;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("المبلغ اإلجمالي", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("\n.", new Font(bf, 4, Font.BOLD, BaseColor.WHITE)));
        pr.Add(new Chunk("\nTotal Price", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthTop = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderWidthRight = 1;
        cell.BorderColor = bc;
        cell.Colspan = 2;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("ر يال", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("  .S.R", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("ه", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("  H.", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("ر يال", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("  .S.R", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("ه", new Font(bf, 10, Font.NORMAL, bc)));
        pr.Add(new Chunk("  H.", new Font(bf, 9, Font.BOLD, bc)));

        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderWidthRight = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.PaddingBottom = 5;
        table1.AddCell(cell);

        DataTable dtTemp = new DataTable();
        dtTemp.Columns.Add("slno");
        for (int i = 1; i <= 10; i++)
        {
            dtTemp.Rows.Add(i.ToString());
        }
        for (int j = 0; j < 10; j++)
        {
            cell = new PdfPCell(new Phrase((j + 1).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["prodDescription"].ToString() : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.PaddingLeft = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["qty"].ToString() : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.PaddingLeft = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["prodPrice"].ToString().Split('.')[0] : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.PaddingRight = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["prodPrice"].ToString().Split('.')[1] : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.PaddingLeft = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["totalPrice"].ToString().Split('.')[0] : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingRight = 5;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase(j < dsQuot.Tables[1].Rows.Count ? dsQuot.Tables[1].Rows[j]["totalPrice"].ToString().Split('.')[1] : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderWidthRight = 1;
            cell.BorderColor = bc;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.PaddingLeft = 5;
            table1.AddCell(cell);
        }

        cell = new PdfPCell(new Phrase("Total Exclusive Vat " + dsQuot.Tables[2].Rows[0]["vatPer"].ToString() + " %", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        cell.PaddingRight = 5;
        cell.PaddingLeft = 5;
        cell.Colspan = 5;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[0], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingRight = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["totalExVat"].ToString().Split('.')[1], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderWidthRight = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.PaddingLeft = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase("Vat " + dsQuot.Tables[2].Rows[0]["vatPer"].ToString() + " %", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        cell.PaddingRight = 5;
        cell.Colspan = 5;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[0], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingRight = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["vatAmt"].ToString().Split('.')[1], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderWidthRight = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.PaddingLeft = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        pr = new Phrase();
        pr.Add(new Chunk("          " + "المجموع :    ", new Font(bf, 11, Font.BOLD)));
        pr.Add(new Chunk("TOTAL :    ", new Font(bf, 10, Font.BOLD)));
        pr.Add(new Chunk(ConvertNumbertoWords(Convert.ToInt32(dsQuot.Tables[2].Rows[0]["totalInTax"])), new Font(bf, 10, Font.NORMAL | Font.UNDERLINE)));


        cell = new PdfPCell(pr);
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        cell.PaddingRight = 5;
        cell.PaddingLeft = 5;
        cell.Colspan = 5;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[0], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell.PaddingRight = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["totalInTax"].ToString().Split('.')[1], FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.BorderWidthLeft = 1;
        cell.BorderWidthBottom = 1;
        cell.BorderWidthRight = 1;
        cell.BorderColor = bc;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.PaddingLeft = 5;
        cell.PaddingTop = 10;
        cell.PaddingBottom = 10;
        table1.AddCell(cell);

        PdfPTable table2 = new PdfPTable(6);
        table2.WidthPercentage = 100;
        float[] width2 = new float[] { 4f, 56f, 8f, 17f, 4f, 17f };
        table2.SetWidths(width2);

        cell = new PdfPCell(new Phrase("Terms & Conditions : ", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.Colspan = 6;
        cell.PaddingTop = 10;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(""));
        cell.Border = 0;
        cell.Rowspan = 2;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(dsQuot.Tables[2].Rows[0]["termsAndContions"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL)));
        cell.Border = 0;
        cell.Rowspan = 2;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(""));
        cell.Border = 0;
        cell.Rowspan = 2;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(""));
        cell.Border = 0;
        cell.Rowspan = 2;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase("Approved By", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(".", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        cell.Border = 0;
        cell.BorderWidthBottom = 1;
        cell.PaddingTop = 20;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase(".", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        cell.Border = 0;
        cell.BorderWidthBottom = 1;
        cell.PaddingTop = 20;
        table2.AddCell(cell);

        cell = new PdfPCell(new Phrase("We, TRIGNOTEC, look forward for your valuable order and please don't hesitate to contact\nus for any queries.", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        cell.Border = 0;
        cell.PaddingLeft = 70;
        cell.PaddingTop = 20;
        cell.Colspan = 6;
        table2.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Terms & Conditions : ", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        //cell.Border = 0;
        //cell.Colspan = 7;
        //cell.PaddingTop = 10;
        //table1.AddCell(cell);

        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = 0;
        //cell.Rowspan = 4;
        //table1.AddCell(cell);

        //pr = new Phrase();
        //pr.Add(new Chunk("Validity :", new Font(bf, 8, Font.BOLD | Font.UNDERLINE)));
        //pr.Add(new Chunk(" 5-10 ", new Font(bf, 8, Font.BOLD)));
        //pr.Add(new Chunk("Days from the date of Quotation.", new Font(bf, 8, Font.NORMAL)));

        //cell = new PdfPCell(pr);
        //cell.Border = 0;
        //cell.Colspan = 2;
        //table1.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        //cell.Border = 0;
        //cell.Colspan = 2;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table1.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Approved By", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        //cell.Border = 0;
        //cell.Colspan = 2;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table1.AddCell(cell);

        //pr = new Phrase();
        //pr.Add(new Chunk("Payment :", new Font(bf, 8, Font.BOLD | Font.UNDERLINE)));
        //pr.Add(new Chunk(" 100% - Down payment\n                      All the prices quoted are in Saudi Riyals", new Font(bf, 8, Font.NORMAL)));

        //cell = new PdfPCell(pr);
        //cell.Border = 0;
        //cell.Colspan = 2;
        //table1.AddCell(cell);

        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = 0;
        //cell.Colspan = 4;
        //table1.AddCell(cell);

        //pr = new Phrase();
        //pr.Add(new Chunk("Support :", new Font(bf, 8, Font.BOLD | Font.UNDERLINE)));
        //pr.Add(new Chunk(" All Supports will be provided by our trained Engineers", new Font(bf, 8, Font.NORMAL)));

        //cell = new PdfPCell(pr);
        //cell.Border = 0;
        //cell.Colspan = 6;
        //table1.AddCell(cell);

        //PdfPTable table2 = new PdfPTable(4);
        //table2.WidthPercentage = 100;
        //float[] width2 = new float[] { 60f, 18f, 4f, 18f };
        //table2.SetWidths(width2);

        //pr = new Phrase();
        //pr.Add(new Chunk("Warranty :", new Font(bf, 8, Font.BOLD | Font.UNDERLINE)));
        //pr.Add(new Chunk(" 2 Years Product Warranty", new Font(bf, 8, Font.NORMAL)));

        //cell = new PdfPCell(pr);
        //cell.Border = 0;
        //cell.PaddingLeft = 48;
        //table2.AddCell(cell);

        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        //table2.AddCell(cell);

        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = 0;
        //table2.AddCell(cell);

        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = 0;
        //cell.BorderWidthBottom = 1;
        //table2.AddCell(cell);

        //cell = new PdfPCell(new Phrase("We, TRIGNOTEC, look forward for your valuable order and please don't hesitate to contact\nus for any queries.", FontFactory.GetFont("Arial", 10, Font.BOLD)));
        //cell.Border = 0;
        //cell.PaddingLeft = 70;
        //cell.PaddingTop = 20;
        //cell.Colspan = 4;
        //table2.AddCell(cell);

        doc.Add(table);
        doc.Add(table1);
        doc.Add(table2);

        doc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=QuotationNo( " + lblQuotationNo.Text + " ).pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(doc);
        Response.End();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            quotObj = new QuotationClass();
            quotObj.quotId = Convert.ToInt32(Request.QueryString["qid"]);
            DataSet dsQuot = quotObj.GetQuotationDetailsByQuotId();
            if (dsQuot.Tables[0].Rows.Count > 0)
            {
                printQuotation(dsQuot);
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
            quotObj = new QuotationClass();
            quotObj.quotId = Convert.ToInt32(Request.QueryString["qid"]);
            Response.Redirect("~/Windows/Default.aspx?uc=8&qid=" + quotObj.quotId);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}