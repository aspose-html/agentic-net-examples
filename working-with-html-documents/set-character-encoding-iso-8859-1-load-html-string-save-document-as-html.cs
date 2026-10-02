// Set character encoding to ISO-8859-1, load an HTML string, and save the document as HTML.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with ISO-8859-1 encoding if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"ISO-8859-1\"><title>Sample</title></head><body><p>Olá, mundo!</p></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.GetEncoding("ISO-8859-1"));
            }

            // Load HTML content using ISO-8859-1 encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("ISO-8859-1"));

            // Create HTMLDocument from the content (base URI placeholder)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Save the document as HTML
            document.Save(outputPath);

            Console.WriteLine("HTML document saved successfully to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}