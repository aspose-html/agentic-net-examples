// Remove all noscript elements to simplify the DOM for environments without JavaScript.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><noscript>JavaScript is disabled</noscript><p>Sample content</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Get all <noscript> elements
                HTMLCollection noscripts = document.GetElementsByTagName("noscript");

                // Iterate in reverse order and remove each element
                for (int i = noscripts.Length - 1; i >= 0; i--)
                {
                    Element noscript = noscripts[i];
                    if (noscript.ParentNode != null)
                    {
                        noscript.ParentNode.RemoveChild(noscript);
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Noscript elements removed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}