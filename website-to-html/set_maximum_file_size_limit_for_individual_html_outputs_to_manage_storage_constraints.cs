// Set a maximum file size limit for individual HTML outputs to manage storage constraints.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string inputPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This is a test document.</p>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Set HTML save options with resource handling depth
            var htmlSaveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            htmlSaveOptions.ResourceHandlingOptions.MaxHandlingDepth = 5;
            htmlSaveOptions.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Save as HTML
            string htmlOutputPath = "output.html";
            document.Save(htmlOutputPath, htmlSaveOptions);
            Console.WriteLine($"HTML saved to: {Path.GetFullPath(htmlOutputPath)}");

            // Convert to MHTML using Converter
            var mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            mhtmlOptions.ResourceHandlingOptions.MaxHandlingDepth = 5;

            string mhtmlOutputPath = "output.mhtml";
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, mhtmlOptions, mhtmlOutputPath);
            Console.WriteLine($"MHTML saved to: {Path.GetFullPath(mhtmlOutputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}