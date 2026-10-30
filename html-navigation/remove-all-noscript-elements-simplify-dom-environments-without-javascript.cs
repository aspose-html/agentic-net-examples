// Remove all noscript elements to simplify the DOM for environments without JavaScript.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<html><head></head><body><noscript>Sample</noscript><p>Content</p></body></html>");
            }

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all noscript elements
            Aspose.Html.Collections.HTMLCollection noscripts = document.GetElementsByTagName("noscript");

            // Iterate safely and remove
            for (int i = noscripts.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element noscript = (Aspose.Html.Dom.Element)noscripts[i];
                if (noscript.ParentNode != null)
                {
                    noscript.ParentNode.RemoveChild(noscript);
                }
            }

            // Save document
            document.Save(outputPath);

            Console.WriteLine("Noscript elements removed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}