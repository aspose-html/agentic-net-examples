// Add a custom attribute to heading nodes for SEO purposes without altering visible text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file path
            string outputPath = "output.html";

            // Create a new HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Get the body element
            var body = document.Body;

            // Create an <h1> heading element
            var h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");

            // Add a custom SEO attribute without changing visible text
            h1.SetAttribute("data-seo", "true");

            // Add visible text to the heading
            var headingText = document.CreateTextNode("Welcome to My Site");
            h1.AppendChild(headingText);

            // Append the heading to the body
            body.AppendChild(h1);

            // Save the document to a file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}