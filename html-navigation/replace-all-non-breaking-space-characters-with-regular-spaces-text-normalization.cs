// Replace all occurrences of non‑breaking space characters with regular spaces for text normalization.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "Hello\u00A0World! This\u00A0is\u00A0a\u00A0test.";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.Body;
            string bodyHtml = body.InnerHTML;
            string normalized = bodyHtml.Replace('\u00A0', ' ');
            body.InnerHTML = normalized;

            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, options);

            Console.WriteLine("Normalization completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}