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
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-16\"></head><body></body></html>";
            string baseUri = ".";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
            document.Save(outputPath);

            string savedContent = File.ReadAllText(outputPath, Encoding.Unicode);
            if (savedContent.Contains("UTF-16"))
            {
                Console.WriteLine("Meta charset UTF-16 verified.");
            }
            else
            {
                Console.WriteLine("Verification failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}