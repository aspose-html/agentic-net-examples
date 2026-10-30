// Save each downloaded external SVG to a local .svg file preserving the original file name.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a sample HTML file with an external SVG reference
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src=\"https://upload.wikimedia.org/wikipedia/commons/6/6b/Bitmap_VS_SVG.svg\" alt=\"example\"/>" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Find all <img> elements whose src ends with .svg
            Aspose.Html.Collections.NodeList svgElements = document.QuerySelectorAll("img[src$='.svg']");

            // Ensure output directory exists
            string outputDir = "svgs";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < svgElements.Length; i++)
                {
                    HTMLElement imgElement = (HTMLElement)svgElements[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Determine file name from URL
                    Uri uri = new Uri(src);
                    string fileName = Path.GetFileName(uri.LocalPath);
                    if (string.IsNullOrEmpty(fileName))
                        continue;

                    // Download SVG content
                    byte[] svgData = httpClient.GetByteArrayAsync(src).Result;

                    // Save to local file preserving original name
                    string outputPath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(outputPath, svgData);

                    Console.WriteLine($"Saved SVG: {outputPath}");
                }
            }

            // Optionally save the (unchanged) HTML document
            string outputHtml = "output.html";
            document.Save(outputHtml);
            Console.WriteLine($"Processed HTML saved to: {outputHtml}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}