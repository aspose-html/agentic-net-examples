// Create a new HTML document, set its base URL, and resolve relative links accordingly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create an HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Define output file path
            string outputPath = "output.html";

            // Save the document to a file
            document.Save(outputPath);

            // Retrieve the outer HTML of the document
            string outerHTML = document.DocumentElement.OuterHTML;

            // Print the outer HTML to the console
            Console.WriteLine("Document saved to: " + outputPath);
            Console.WriteLine("Outer HTML:");
            Console.WriteLine(outerHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}