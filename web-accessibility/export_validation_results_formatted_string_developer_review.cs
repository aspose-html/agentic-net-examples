// Export validation results as a formatted string using SaveToString for developer review.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            string baseUri = "http://example.com/";

            // -----------------------------------------------------------------
            // 1. Convert HTML to MHTML
            // -----------------------------------------------------------------
            string mhtmlOutputPath = "output.mhtml";
            var mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mhtmlOptions, mhtmlOutputPath);
            Console.WriteLine($"MHTML saved to: {mhtmlOutputPath}");

            // -----------------------------------------------------------------
            // 2. Accessibility validation
            // -----------------------------------------------------------------
            string htmlFilePath = "sample.html";
            File.WriteAllText(htmlFilePath, htmlContent);

            using (var document = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                var validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                var validationResult = validator.Validate(document);

                string validationXml;
                using (var sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    validationXml = sw.ToString();
                }

                Console.WriteLine("Accessibility validation result (XML):");
                Console.WriteLine(validationXml);
            }

            // -----------------------------------------------------------------
            // 3. Save as Markdown (file path overload)
            // -----------------------------------------------------------------
            string markdownPath1 = "output1.md";
            using (var doc = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                doc.Save(markdownPath1, Aspose.Html.Saving.HTMLSaveFormat.Markdown);
            }
            Console.WriteLine($"Markdown saved to: {markdownPath1}");

            // -----------------------------------------------------------------
            // 4. Save as Markdown (HTML string + base URI overload)
            // -----------------------------------------------------------------
            string markdownPath2 = "output2.md";
            using (var doc = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                doc.Save(markdownPath2, Aspose.Html.Saving.HTMLSaveFormat.Markdown);
            }
            Console.WriteLine($"Markdown saved to: {markdownPath2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}