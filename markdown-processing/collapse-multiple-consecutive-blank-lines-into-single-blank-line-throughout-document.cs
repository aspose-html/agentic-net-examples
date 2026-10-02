// Collapse multiple consecutive blank lines into a single blank line throughout the document.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<html>
<head>
<title>Sample</title>
</head>

<body>

<h1>Header</h1>


<p>Paragraph with

multiple blank lines.</p>


</body>
</html>";
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                string originalHtml = doc.DocumentElement.OuterHTML;
                string collapsedHtml = Regex.Replace(originalHtml, @"(\r?\n){2,}", "\n");
                using (Aspose.Html.HTMLDocument outputDoc = new Aspose.Html.HTMLDocument(collapsedHtml, "about:blank"))
                {
                    string outputPath = "output.html";
                    outputDoc.Save(outputPath);
                    Console.WriteLine($"Document saved to {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}