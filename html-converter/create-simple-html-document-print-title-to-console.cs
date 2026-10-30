// Create a simple HTML document and print its title to the console.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Set the document title
            document.Title = "Sample Document";

            // Add a heading to the body (optional)
            var body = document.Body;
            var h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.AppendChild(document.CreateTextNode("Hello, Aspose.HTML!"));
            body.AppendChild(h1);

            // Print the title to the console
            Console.WriteLine("Document title: " + document.Title);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}