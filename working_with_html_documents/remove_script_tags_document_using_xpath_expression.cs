// Remove all <script> tags from the document using an XPath expression.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve all <script> elements
            var scripts = document.GetElementsByTagName("script");

            // Remove each script element starting from the end
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}