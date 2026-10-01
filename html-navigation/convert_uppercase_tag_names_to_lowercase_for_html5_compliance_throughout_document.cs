// Convert all uppercase tag names to lowercase to ensure HTML5 compliance throughout the document.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with uppercase tag names
            string htmlContent = "<HTML><HEAD><TITLE>Sample</TITLE></HEAD><BODY><DIV>Content</DIV></BODY></HTML>";

            // Load HTML into Aspose.Html.HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Get the outer HTML of the document
            string originalHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;

            // Convert uppercase tag names to lowercase using regex
            string lowerCaseHtml = Regex.Replace(originalHtml, @"<\s*/?\s*([A-Z][A-Z0-9]*)", m =>
            {
                string tag = m.Groups[1].Value;
                return m.Value.Replace(tag, tag.ToLowerInvariant());
            });

            // Define output path
            string outputPath = "output.html";

            // Save the transformed HTML to a file
            File.WriteAllText(outputPath, lowerCaseHtml);

            Console.WriteLine("HTML tags converted to lowercase and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}