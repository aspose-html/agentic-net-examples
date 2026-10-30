// Set custom margins and page size in PdfSaveOptions while converting MHTML to PDF for printing.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.pdf";

                if (!System.IO.File.Exists(inputPath))
                {
                    string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""; start=""file:///C:/sample.html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable
Content-Location: file:///C:/sample.html

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(inputPath, mhtmlContent);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.AliceBlue;

                    Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(11));

                    Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Unit.FromInches(1),
                        Aspose.Html.Drawing.Unit.FromInches(1),
                        Aspose.Html.Drawing.Unit.FromInches(1),
                        Aspose.Html.Drawing.Unit.FromInches(1));

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margins);
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}