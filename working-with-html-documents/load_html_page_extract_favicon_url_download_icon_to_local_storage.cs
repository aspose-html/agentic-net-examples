// Load an HTML page, extract its favicon URL, download the icon to local storage.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pageUrl = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl);
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("link");
            string faviconUrlString = null;
            for (int i = 0; i < links.Length; i++)
            {
                Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)links[i];
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel))
                    continue;
                if (!rel.ToLowerInvariant().Contains("icon"))
                    continue;
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;
                Aspose.Html.Url faviconUrl = new Aspose.Html.Url(href, document.BaseURI);
                faviconUrlString = faviconUrl.ToString();
                break;
            }

            if (string.IsNullOrEmpty(faviconUrlString))
            {
                System.Console.WriteLine("Favicon not found.");
                return;
            }

            Aspose.Html.HTMLDocument downloader = new Aspose.Html.HTMLDocument();
            Aspose.Html.Url url = new Aspose.Html.Url(faviconUrlString);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = downloader.Context.Network.Send(request);
            bool isSuccess = response.IsSuccess;
            if (!isSuccess)
            {
                System.Console.WriteLine("Failed to download favicon. HTTP status: " + response.StatusCode);
                return;
            }

            System.Byte[] contentBytes = response.Content.ReadAsByteArray();
            string fileName = System.IO.Path.GetFileName(faviconUrlString);
            if (string.IsNullOrEmpty(fileName))
                fileName = "favicon.ico";
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName);
            System.IO.File.WriteAllBytes(outputPath, contentBytes);
            System.Console.WriteLine("Favicon saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}