// Save each downloaded external SVG to a local .svg file preserving the original file name.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><img src='https://example.com/image1.svg' alt='svg1'/><img src='https://example.com/image2.png' alt='png'/></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.NodeList svgElements = document.QuerySelectorAll("img[src$='.svg']");

            for (int i = 0; i < svgElements.Length; i++)
            {
                HTMLElement imgElement = (HTMLElement)svgElements[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                using (HttpClient client = new HttpClient())
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(src);
                    responseTask.Wait();
                    HttpResponseMessage response = responseTask.Result;
                    response.EnsureSuccessStatusCode();

                    Task<byte[]> bytesTask = response.Content.ReadAsByteArrayAsync();
                    bytesTask.Wait();
                    byte[] data = bytesTask.Result;

                    string fileName = Path.GetFileName(new Uri(src).LocalPath);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = "downloaded.svg";

                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                    File.WriteAllBytes(outputPath, data);
                    Console.WriteLine($"Saved SVG to {outputPath}");
                }
            }

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}