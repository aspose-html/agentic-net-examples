// Load an HTML file from disk into the validator using the Load method with a file path argument.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "input.html";
            var document = new HTMLDocument(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}