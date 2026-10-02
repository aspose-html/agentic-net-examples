// Implement error handling that catches conversion exceptions and logs source file path for failed MHTML.

using System;

class Program
{
    static void Main()
    {
        string sourcePath = "sample.mht";
        string outputPath = "output.doc";

        try
        {
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            System.Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Failed to convert MHTML file: " + sourcePath);
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}