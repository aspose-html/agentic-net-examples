// Save the modified HTML document back to the original file location.

using System;
using Aspose.Html;

namespace HtmlSaveExample
{
    class Program
    {
        static void Main()
        {
            string filePath = "example.html";
            try
            {
                HTMLDocument document = new HTMLDocument(filePath);
                document.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}