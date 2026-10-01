// Implement ICreateStreamProvider to direct SVG conversion output into a network stream for remote storage.

using System;
using System.IO;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string baseUri = "http://example.com/";
            string outputPath = "output.pdf";

            // Ensure any existing file is removed
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            // Convert SVG to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

            // Read the generated PDF
            byte[] payload = File.ReadAllBytes(outputPath);

            // Send PDF over TCP
            string host = "localhost";
            int port = 9000;

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream networkStream = client.GetStream())
            {
                networkStream.Write(payload, 0, payload.Length);
                networkStream.Flush();
            }

            Console.WriteLine("SVG converted to PDF and sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}