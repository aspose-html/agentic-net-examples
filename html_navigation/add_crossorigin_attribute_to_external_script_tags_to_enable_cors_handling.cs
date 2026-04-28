// Add a crossorigin attribute to external script tags to enable CORS handling.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            // Load HTML content from file
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.UTF8);
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Get all script elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Element scriptElement = (Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    // Add crossorigin attribute
                    scriptElement.SetAttribute("crossorigin", "anonymous");
                }
            }

            // Save the modified HTML
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}