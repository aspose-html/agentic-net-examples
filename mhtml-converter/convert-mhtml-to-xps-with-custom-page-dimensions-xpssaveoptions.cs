// Convert an MHTML file to XPS format while specifying custom page dimensions in XpsSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "From: <saved by Aspose.HTML>\r\n" +
                                      "Subject: Sample MHTML\r\n" +
                                      "Date: Thu, 1 Jan 1970 00:00:00 GMT\r\n" +
                                      "MIME-Version: 1.0\r\n" +
                                      "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                      "------=_NextPart_000_0000\r\n" +
                                      "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                                      "Content-Transfer-Encoding: 7bit\r\n\r\n" +
                                      "<html><body><h1>Hello, MHTML!</h1></body></html>\r\n\r\n" +
                                      "------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file as a read stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure XPS save options with custom page size and background color
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.3f),
                        Aspose.Html.Drawing.Length.FromInches(5.8f)));
                options.BackgroundColor = Color.LightGray;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}