// Update existing base tag href attribute to a new domain for site migration.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string newDomain = "https://newsite.com/";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <base href=""http://oldsite.com/"" />
    <title>Sample Page</title>
</head>
<body>
    <p>Hello World!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Find the <base> element
                Aspose.Html.Collections.HTMLCollection baseElements = document.GetElementsByTagName("base");
                if (baseElements.Length > 0)
                {
                    Aspose.Html.HTMLElement baseElement = (Aspose.Html.HTMLElement)baseElements[0];
                    // Update the href attribute to the new domain
                    baseElement.SetAttribute("href", newDomain);
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Base tag href updated and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}