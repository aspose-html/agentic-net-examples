// Load an HTML page, extract its favicon URL, download the icon to local storage.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pageUrl = "https://example.com";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl))
            {
                Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("link");
                string faviconUrl = null;

                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)links[i];
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel))
                        continue;

                    if (rel.IndexOf("icon", System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string href = linkElement.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                            faviconUrl = resolvedUrl.ToString();
                            break;
                        }
                    }
                }

                if (faviconUrl == null)
                {
                    System.Console.WriteLine("Favicon not found.");
                    return;
                }

                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    byte[] iconBytes = httpClient.GetByteArrayAsync(faviconUrl).GetAwaiter().GetResult();
                    string fileName = System.IO.Path.GetFileName(new System.Uri(faviconUrl).AbsolutePath);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = "favicon.ico";

                    string savePath = System.IO.Path.Combine(outputDir, fileName);
                    System.IO.File.WriteAllBytes(savePath, iconBytes);
                    System.Console.WriteLine($"Favicon saved to {savePath}");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}