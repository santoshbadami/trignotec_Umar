using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;

public partial class trignotec_quotation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Document doc = new Document(PageSize.A4, 20f, 15f, 25f, 5f);//left-right-top-bottom
            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
            BaseColor bc = new BaseColor(47, 70, 162);

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

            cell = new PdfPCell(new Phrase("Q128", FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(219, 39, 123))));
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

            cell = new PdfPCell(new Phrase("03rd May, 2018", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, Font.BOLD | Font.UNDERLINE, bc)));
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

            cell = new PdfPCell(new Phrase("Umar", new Font(bf, 12, Font.BOLD, bc)));
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
            for (int j = 0; j < dtTemp.Rows.Count; j++)
            {
                cell = new PdfPCell(new Phrase(dtTemp.Rows[j]["slno"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);

                cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
                cell.Border = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.BorderWidthRight = 1;
                cell.BorderColor = bc;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingTop = 5;
                cell.PaddingBottom = 5;
                table1.AddCell(cell);
            }

            cell = new PdfPCell(new Phrase("Total Exclusive Vat 5 %", FontFactory.GetFont("Arial", 10, Font.BOLD)));
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

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderWidthRight = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase("Vat 5 %", FontFactory.GetFont("Arial", 10, Font.BOLD)));
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

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderWidthRight = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            pr = new Phrase();
            pr.Add(new Chunk("          " + "المجموع :    ", new Font(bf, 11, Font.BOLD)));
            pr.Add(new Chunk("TOTAL :    ", new Font(bf, 10, Font.BOLD)));
            pr.Add(new Chunk("One thousand and fifty", new Font(bf, 10, Font.NORMAL | Font.UNDERLINE)));


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

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthBottom = 1;
            cell.BorderWidthRight = 1;
            cell.BorderColor = bc;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table1.AddCell(cell);

            cell = new PdfPCell(new Phrase("Terms & Conditions : ", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell.Border = 0;
            cell.Colspan = 7;
            cell.PaddingTop = 10;
            table1.AddCell(cell);

            pr = new Phrase();
            pr.Add(new Chunk("Validity :", new Font(bf, 10, Font.BOLD | Font.UNDERLINE)));
            pr.Add(new Chunk("5-10 ", new Font(bf, 10, Font.BOLD)));
            pr.Add(new Chunk("Days from the date of Qrotation.", new Font(bf, 10, Font.BOLD)));

            cell = new PdfPCell(pr);
            cell.Border = 0;
            table1.AddCell(cell);

            doc.Add(table);
            doc.Add(table1);

            doc.Close();
            Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=demo.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();
        }
    }
}