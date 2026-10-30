// Log detailed extraction steps to a file using Serilog for troubleshooting purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        const string logPath = "extraction.log";
        const string htmlPath = "sample.html";

        try
        {
            // Clear previous log
            if (File.Exists(logPath))
                File.Delete(logPath);

            // Step 1: Create a minimal HTML file with images
            File.AppendAllText(logPath, "Step 1: Creating sample HTML file" + Environment.NewLine);
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Test Images</h1>
    <img src='image1.png' alt='Image 1' />
    <img src='image2.jpg' alt='Image 2' />
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);
            File.AppendAllText(logPath, $"Sample HTML written to {htmlPath}" + Environment.NewLine);

            // Step 2: Load the HTML document
            File.AppendAllText(logPath, "Step 2: Loading HTML document" + Environment.NewLine);
            HTMLDocument doc = new HTMLDocument(htmlPath);
            File.AppendAllText(logPath, "HTML document loaded successfully" + Environment.NewLine);

            // Step 3: Evaluate XPath to select all img elements
            File.AppendAllText(logPath, "Step 3: Evaluating XPath '//img'" + Environment.NewLine);
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
            File.AppendAllText(logPath, "XPath evaluation completed" + Environment.NewLine);

            // Step 4: Iterate over results and log each image source
            File.AppendAllText(logPath, "Step 4: Iterating over image nodes" + Environment.NewLine);
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLImageElement img = (HTMLImageElement)node;
                File.AppendAllText(logPath, $"Found image src: {img.Src}" + Environment.NewLine);
            }

            File.AppendAllText(logPath, "Extraction completed successfully" + Environment.NewLine);
            Console.WriteLine("Extraction finished. See extraction.log for details.");
        }
        catch (Exception ex)
        {
            File.AppendAllText(logPath, "Error: " + ex.Message + Environment.NewLine);
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}