// Identify and list all external script source URLs for dependency analysis in the document.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path or URL of the HTML document to analyze.
            string source = args.Length > 0 ? args[0] : "example.html";

            // Load the HTML document.
            HTMLDocument document = new HTMLDocument(source);

            // Retrieve all <script> elements.
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            // Iterate through each script element and output its src attribute if present.
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Element scriptElement = (Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}