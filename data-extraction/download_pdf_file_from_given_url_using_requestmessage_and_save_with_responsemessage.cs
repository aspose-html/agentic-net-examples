// Download a PDF file from a given URL using RequestMessage and save it with ResponseMessage.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the PDF to download
            string pdfUrl = "https://example.com/sample.pdf";

            // Destination file path
            string outputPath = Path.Combine(Path.GetTempPath(), "downloaded.pdf");

            // Create request
            Aspose.Html.Url url = new Aspose.Html.Url(pdfUrl);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

            // Send request using a temporary HTMLDocument context
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                if (!response.IsSuccess)
                {
                    throw new Exception($"Failed to download PDF. Status code: {response.StatusCode}");
                }

                byte[] contentBytes = response.Content.ReadAsByteArray();

                // Save the PDF to the specified path
                File.WriteAllBytes(outputPath, contentBytes);
            }

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}