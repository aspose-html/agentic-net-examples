// Save the cleaned HTML document after removing script elements from it.

using System;
using Aspose.Html;

namespace RemoveScriptsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";
                // Path where the cleaned HTML will be saved
                string outputPath = "output.html";

                // Load the HTML document from the file system
                HTMLDocument document = new HTMLDocument(inputPath);

                // Retrieve all <script> elements in the document
                var scripts = document.GetElementsByTagName("script");

                // Remove each script element starting from the end of the collection
                for (int i = scripts.Length - 1; i >= 0; i--)
                {
                    var script = scripts[i];
                    if (script.ParentNode != null)
                    {
                        script.ParentNode.RemoveChild(script);
                    }
                }

                // Save the modified document without script elements
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}