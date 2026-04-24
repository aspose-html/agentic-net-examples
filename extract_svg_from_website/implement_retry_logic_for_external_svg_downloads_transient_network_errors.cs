// Implement retry logic for external SVG downloads that fail due to transient network errors.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string svgUrl = "https://example.com/image.svg";
            string outputPath = "downloaded.svg";
            int maxRetries = 3;
            int delayMs = 2000;
            byte[] svgBytes = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
                Aspose.Html.Url url = new Aspose.Html.Url(svgUrl);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                Aspose.Html.Net.ResponseMessage response = doc.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    svgBytes = response.Content.ReadAsByteArray();
                    break;
                }
                if (attempt < maxRetries)
                    System.Threading.Thread.Sleep(delayMs);
            }

            if (svgBytes == null)
                throw new Exception("Failed to download SVG after retries.");

            using (MemoryStream ms = new MemoryStream(svgBytes))
            {
                SVGDocument svgDoc = new SVGDocument(ms, svgUrl);
                svgDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}