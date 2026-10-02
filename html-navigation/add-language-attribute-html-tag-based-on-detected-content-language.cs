// Add a language attribute to the html tag based on detected content language.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>Hello world!</body></html>";
            // Simple language detection based on content
            string languageCode = htmlContent.Contains("Bonjour") ? "fr" : "en";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLElement htmlElement = (Aspose.Html.HTMLElement)document.DocumentElement;
            htmlElement.SetAttribute("lang", languageCode);

            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("HTML saved to " + outputPath + " with lang='" + languageCode + "'.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}