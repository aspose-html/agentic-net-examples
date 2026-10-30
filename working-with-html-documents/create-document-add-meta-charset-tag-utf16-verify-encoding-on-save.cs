// Create a document, add a meta charset tag for UTF‑16, and verify correct encoding on save.

using System;
using System.IO;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            string sourceHtml = "<!DOCTYPE html><html><head></head><body></body></html>";

            using (var document = new Aspose.Html.HTMLDocument(sourceHtml, "about:blank"))
            {
                // Create meta charset tag for UTF-16
                var meta = document.CreateElement("meta");
                meta.SetAttribute("charset", "UTF-16");

                // Append meta to <head>
                var headElements = document.GetElementsByTagName("head");
                if (headElements.Length > 0)
                {
                    var head = headElements[0];
                    head.AppendChild(meta);
                }

                // Save document
                document.Save(outputPath);
            }

            // Verify saved file contains UTF-16 charset meta tag
            byte[] savedBytes = File.ReadAllBytes(outputPath);
            string savedContent = Encoding.GetEncoding("UTF-16").GetString(savedBytes);
            bool containsMeta = savedContent.Contains("charset=\"UTF-16\"");
            Console.WriteLine("Meta charset UTF-16 present: " + containsMeta);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}