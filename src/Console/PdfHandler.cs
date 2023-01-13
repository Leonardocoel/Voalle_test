using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;

namespace ConsoleProgram;


public static class PdfHandler
{

    public static void SavePdf(string shape)
    {
        var pdfDoc = new PdfDocument(new PdfWriter("shape.pdf"));
        var document = new Document(pdfDoc, PageSize.A4);

        var paragraph = new Paragraph();
        paragraph.SetTextAlignment(TextAlignment.CENTER);
        paragraph.SetFontSize(8);
        paragraph.Add(shape);

        document.Add(paragraph);
        document.Close();
    }

    public static void Message(string shape)
    {
        Console.WriteLine("Gostaria de salvar o resultado como pdf? [Y/n]");

        bool response = Helpers.Confirmation();

        if (response)
        {
            SavePdf(shape);
        }

    }

}