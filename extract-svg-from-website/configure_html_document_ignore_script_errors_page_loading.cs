// Configure HtmlDocument to ignore script errors during page loading.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with a script that throws an error
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<html><head><script>throw new Error('test');</script></head><body><p>Hello World</p></body></html>");
            }

            // Configure the HTML engine to allow script execution (errors will be ignored)
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document with the configured settings
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Save the processed document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}