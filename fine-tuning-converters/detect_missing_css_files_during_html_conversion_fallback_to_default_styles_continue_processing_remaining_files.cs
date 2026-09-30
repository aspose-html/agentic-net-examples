// Detect missing CSS files during HTML conversion, fallback to default styles, and continue processing remaining files.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] htmlFiles = new string[]
            {
                "sample1.html",
                "sample2.html"
            };

            foreach (string htmlPath in htmlFiles)
            {
                try
                {
                    // Load the HTML document
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                    // Set conversion options
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                    // Define output path
                    string outputPath = Path.ChangeExtension(htmlPath, ".xps");

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Primary conversion failed for '{htmlPath}': {ex.Message}");
                    try
                    {
                        // Read original HTML content
                        string htmlContent = File.ReadAllText(htmlPath);

                        // Default CSS to apply when external CSS is missing
                        string defaultCss = "body { font-family: Arial, sans-serif; color: #000000; }";
                        string styleTag = $"<style>{defaultCss}</style>";

                        // Inject the default CSS into the document
                        if (htmlContent.IndexOf("<head>", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int headIndex = htmlContent.IndexOf("<head>", StringComparison.OrdinalIgnoreCase) + "<head>".Length;
                            htmlContent = htmlContent.Insert(headIndex, styleTag);
                        }
                        else if (htmlContent.IndexOf("<html>", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int htmlIndex = htmlContent.IndexOf("<html>", StringComparison.OrdinalIgnoreCase) + "<html>".Length;
                            string headSection = $"<head>{styleTag}</head>";
                            htmlContent = htmlContent.Insert(htmlIndex, headSection);
                        }
                        else
                        {
                            // If no <head> or <html> tags, prepend the style tag
                            htmlContent = $"<head>{styleTag}</head>{htmlContent}";
                        }

                        // Save the modified HTML to a temporary file
                        string fallbackPath = Path.Combine(
                            Path.GetDirectoryName(htmlPath) ?? "",
                            Path.GetFileNameWithoutExtension(htmlPath) + "_fallback.html");
                        File.WriteAllText(fallbackPath, htmlContent);

                        // Load the fallback document
                        Aspose.Html.HTMLDocument fallbackDoc = new Aspose.Html.HTMLDocument(fallbackPath);
                        Aspose.Html.Saving.XpsSaveOptions fallbackOptions = new Aspose.Html.Saving.XpsSaveOptions();
                        string fallbackOutput = Path.ChangeExtension(htmlPath, ".xps");

                        // Perform conversion with fallback styles
                        Aspose.Html.Converters.Converter.ConvertHTML(fallbackDoc, fallbackOptions, fallbackOutput);

                        Console.WriteLine($"Fallback conversion succeeded for '{htmlPath}' to '{fallbackOutput}'.");
                    }
                    catch (Exception fallbackEx)
                    {
                        Console.WriteLine($"Fallback conversion also failed for '{htmlPath}': {fallbackEx.Message}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}