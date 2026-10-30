// Update the text of an ATX heading while preserving its original number of hash symbols.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with an ATX heading (markdown style)
            string htmlContent = "<html><body><p># Old Heading</p></body></html>";
            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Locate the paragraph containing the heading
            var paragraph = (Aspose.Html.HTMLElement)document.Body.FirstChild;
            var oldTextNode = (Aspose.Html.Dom.Text)paragraph.FirstChild;

            // Preserve the original number of hash symbols
            string oldText = oldTextNode.Data;
            int hashCount = oldText.TakeWhile(c => c == '#').Count();
            string newHeadingText = new string('#', hashCount) + " Updated Heading";

            // Replace the text node with the new heading text
            var newTextNode = document.CreateTextNode(newHeadingText);
            paragraph.ReplaceChild(newTextNode, oldTextNode);

            // Save the modified document as MHTML (input for conversion)
            string inputMhtmlPath = "sample.mhtml";
            document.Save(inputMhtmlPath);

            // Convert MHTML to DOCX
            string outputDocxPath = "result.docx";
            using (Stream inputStream = File.OpenRead(inputMhtmlPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputDocxPath);
            }

            // Compute SHA-256 hash of the resulting DOCX file
            byte[] outputBytes = File.ReadAllBytes(outputDocxPath);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                Console.WriteLine($"Output DOCX Path: {outputDocxPath}");
                Console.WriteLine($"SHA-256 Hash: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}