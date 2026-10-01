// Load an HTML file from disk into the validator using the Load method with a file path argument.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            System.Console.WriteLine("HTML document loaded successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}