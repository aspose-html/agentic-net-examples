// Create a new HTML document, import an external CSS file, and export the combined result as HTML.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string cssFile = "styles.css";
            File.WriteAllText(cssFile, "body { background-color: #f0f0f0; }");

            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<link rel=""stylesheet"" href=""styles.css"">
</head>
<body>
<h1>Hello World</h1>
</body>
</html>";

            string baseUri = Path.GetFullPath(".");
            string outputPath = "combined.html";

            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}