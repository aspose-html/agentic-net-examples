// Collapse multiple consecutive blank lines into a single blank line throughout the document.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n<title>Sample</title>\n</head>\n<body>\n<h1>Header</h1>\n\n<p>First paragraph.</p>\n\n\n<p>Second paragraph.</p>\n</body>\n</html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("", htmlContent))
            {
                string originalHtml = document.DocumentElement.OuterHTML;
                string collapsedHtml = Regex.Replace(originalHtml, @"(\r?\n){2,}", "\n");
                string outputPath = "output.html";
                using (Aspose.Html.HTMLDocument outputDocument = new Aspose.Html.HTMLDocument("", collapsedHtml))
                {
                    outputDocument.Save(outputPath);
                }
                Console.WriteLine("HTML processed and saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}