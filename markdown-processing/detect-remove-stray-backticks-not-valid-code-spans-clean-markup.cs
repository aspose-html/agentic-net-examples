// Detect and remove stray backticks that do not form valid code spans to clean markup.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "cleaned.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleContent = "<html><body><p>This is a `sample` text with `backticks`.</p></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the full markup of the document
            string originalMarkup = document.DocumentElement.OuterHTML;

            // Remove stray backticks (replace all backticks with empty string)
            string cleanedMarkup = originalMarkup.Replace("`", string.Empty);

            // Create a new document from the cleaned markup
            Aspose.Html.HTMLDocument cleanedDocument = new Aspose.Html.HTMLDocument(cleanedMarkup, "about:blank");

            // Save the cleaned document to the output file
            cleanedDocument.Save(outputPath);

            Console.WriteLine("Backticks removed and document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}