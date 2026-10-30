// Download a PDF file from a given URL using RequestMessage and save it with ResponseMessage.

using System;
using System.IO;

namespace AsposeHtmlDownloadPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // URL of the PDF to download
                string pdfUrl = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf";
                // Destination file path
                string outputPath = Path.Combine(Path.GetTempPath(), "downloaded.pdf");

                // Create a minimal HTMLDocument to access the network API
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("about:blank"))
                {
                    Aspose.Html.Url url = new Aspose.Html.Url(pdfUrl);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    if (!response.IsSuccess)
                    {
                        Console.WriteLine($"Failed to download PDF. Status code: {response.StatusCode}");
                        return;
                    }

                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"PDF successfully downloaded to: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}