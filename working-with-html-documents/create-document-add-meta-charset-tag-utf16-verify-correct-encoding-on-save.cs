// Create a document, add a meta charset tag for UTF‑16, and verify correct encoding on save.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello</p></body></html>";

            // Create HTML document with a base URI
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create <meta charset="UTF-16"> element
            var meta = (Aspose.Html.Dom.Element)document.CreateElement("meta");
            meta.SetAttribute("charset", "UTF-16");

            // Append meta element to <head>
            var headNode = document.GetElementsByTagName("head")[0];
            var head = (Aspose.Html.Dom.Element)headNode;
            head.AppendChild(meta);

            // Save the document to a file
            document.Save(outputPath);

            // Verify that the file is saved with UTF-16 encoding
            byte[] bytes = File.ReadAllBytes(outputPath);
            bool hasBom = bytes.Length >= 2 &&
                          ((bytes[0] == 0xFF && bytes[1] == 0xFE) ||
                           (bytes[0] == 0xFE && bytes[1] == 0xFF));
            string fileContent = Encoding.Unicode.GetString(bytes);
            bool containsMeta = fileContent.Contains("charset=\"UTF-16\"");

            Console.WriteLine("Saved file has UTF-16 BOM: " + hasBom);
            Console.WriteLine("Meta charset UTF-16 present: " + containsMeta);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}