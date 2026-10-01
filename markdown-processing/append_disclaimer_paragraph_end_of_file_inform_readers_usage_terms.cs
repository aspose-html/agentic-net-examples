// Append a disclaimer paragraph at the end of the file to inform readers of usage terms.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Get the body element
                Aspose.Html.HTMLElement body = document.Body;

                // Create a paragraph element
                Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");

                // Set an attribute on the paragraph
                paragraph.SetAttribute("style", "color:blue;");

                // Create a text node
                Aspose.Html.Dom.Text textNode = document.CreateTextNode("Hello, Aspose.HTML!");

                // Append text to paragraph
                paragraph.AppendChild(textNode);

                // Append paragraph to body
                body.AppendChild(paragraph);

                // Define output path
                string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "output.html");

                // Save the document
                document.Save(outputPath);

                Console.WriteLine("HTML document saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}