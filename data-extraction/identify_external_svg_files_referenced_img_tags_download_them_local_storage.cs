// Identify external SVG files referenced by <img> tags and download them to local storage.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputHtmlPath = "input.html";
            string outputHtmlPath = "output.html";
            string svgDownloadFolder = "downloaded_svgs";

            if (!Directory.Exists(svgDownloadFolder))
                Directory.CreateDirectory(svgDownloadFolder);

            string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Test</h1>
    <img src=""https://upload.wikimedia.org/wikipedia/commons/6/6b/Bitmap_VS_SVG.svg"" alt=""Sample SVG"" />
    <img src=""https://example.com/image.png"" alt=""Non-SVG"" />
</body>
</html>";
            File.WriteAllText(inputHtmlPath, sampleHtml);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Find all <img> elements
            var imgElements = document.QuerySelectorAll("img");

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Aspose.Html.HTMLElement imgElement in imgElements)
                {
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    if (src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        // Download SVG content
                        byte[] svgData = httpClient.GetByteArrayAsync(src).GetAwaiter().GetResult();

                        // Determine local file name
                        string fileName = Path.GetFileName(new Uri(src).AbsolutePath);
                        if (string.IsNullOrEmpty(fileName))
                            fileName = "downloaded.svg";

                        string localPath = Path.Combine(svgDownloadFolder, fileName);

                        // Save SVG to local storage
                        File.WriteAllBytes(localPath, svgData);

                        // Update the src attribute to point to the local file
                        imgElement.SetAttribute("src", localPath);
                    }
                }
            }

            // Save the modified HTML document
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}