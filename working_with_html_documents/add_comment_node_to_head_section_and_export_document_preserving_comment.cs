// Add a comment node to the head section, then export the document preserving the comment.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to save the resulting HTML file
            string outputPath = "output.html";

            // Minimal HTML content with head element
            string htmlContent = "<html><head></head><body></body></html>";

            // Load the HTML content into a document
            using (HTMLDocument document = new HTMLDocument(htmlContent, ""))
            {
                // Retrieve the <head> element
                var head = document.GetElementsByTagName("head")[0];

                // Create a comment node
                var comment = document.CreateComment("This is a comment added to the head section");

                // Insert the comment as the first child of the head element
                head.InsertBefore(comment, head.FirstChild);

                // Save the document preserving the comment
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved successfully to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}