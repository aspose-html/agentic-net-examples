// Append a new stylesheet link element to the head to reference an external CSS file.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get or create the <head> element
            HTMLElement head = Enumerable.First(document.GetElementsByTagName("head")) as HTMLElement;
            if (head == null)
            {
                head = (HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Create the <link> element for external CSS
            HTMLElement link = (HTMLElement)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "styles.css");

            // Append the link to the head
            head.AppendChild(link);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("External stylesheet link added. Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}