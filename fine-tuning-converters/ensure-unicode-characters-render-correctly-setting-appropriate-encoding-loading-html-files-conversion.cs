// Ensure Unicode characters render correctly by setting appropriate encoding when loading HTML files for conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.png";

            // Create a sample HTML file with Unicode characters if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body><h1>こんにちは世界 🌍</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Read HTML content using UTF-8 encoding to preserve Unicode characters
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));

            // Load HTML content into a document with a base URI
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Set up image save options (default format is PNG)
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert HTML to an image file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}