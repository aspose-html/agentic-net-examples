// Save a modified HTMLDocument to a MemoryStream with UTF‑8 encoding for further processing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>Hello World</p></body></html>";
            string baseUrl = "about:blank";

            var document = new Aspose.Html.HTMLDocument(html, baseUrl);

            var div = document.CreateElement("div");
            div.TextContent = "Added";
            document.Body.AppendChild(div);

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            var saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            byte[] resultBytes = File.ReadAllBytes(outputPath);
            Console.WriteLine("Saved HTML length (bytes): " + resultBytes.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}