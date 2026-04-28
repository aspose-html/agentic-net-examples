// Retrieve the title element text from a loaded HTML document and store it in a variable.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be loaded
            string htmlPath = "input.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Retrieve the title text
                string titleText = document.Title;

                // Use the title as needed (e.g., display)
                Console.WriteLine("Document Title: " + titleText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}