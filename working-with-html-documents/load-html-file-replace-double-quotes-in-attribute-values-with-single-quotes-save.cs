// Load an HTML file, replace all double quotes in attribute values with single quotes, and save.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input HTML file
            string inputPath = "input.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                    "<a href=\"https://example.com?param=\\\"value\\\"\">Link</a>" +
                                    "<img src=\"image\\\".png\" alt=\"An \\\"image\\\"\" />" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Replace double quotes with single quotes in selected attribute values
            var elements = document.QuerySelectorAll("*");
            string[] attributeNames = new string[] { "href", "src", "title", "alt", "value" };

            foreach (Aspose.Html.Dom.Element element in elements)
            {
                foreach (string attrName in attributeNames)
                {
                    string attrValue = element.GetAttribute(attrName);
                    if (!string.IsNullOrEmpty(attrValue) && attrValue.Contains("\""))
                    {
                        string newValue = attrValue.Replace("\"", "'");
                        element.SetAttribute(attrName, newValue);
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}