// Generate an HTML preview of the Markdown content using the built‑in renderer for visual verification.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.md";
                string savePath = "preview.html";

                if (!System.IO.File.Exists(sourcePath))
                {
                    System.IO.File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **bold** text.");
                }

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    document.Save(savePath);
                    System.Console.WriteLine(document.DocumentElement.OuterHTML);
                    System.Console.WriteLine("Conversion completed. HTML saved at " + savePath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}