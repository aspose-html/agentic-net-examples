// Load an HTML file, remove all script tags, and save the sanitized document to a new file.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            string inputPath = "input.html";
            string outputPath = "output.html";
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve all <script> elements in the document
            var scripts = document.GetElementsByTagName("script");

            // Iterate backwards to safely remove each script node
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // Save the sanitized document to a new file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}