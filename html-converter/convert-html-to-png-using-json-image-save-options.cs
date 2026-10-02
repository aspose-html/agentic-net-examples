// Convert HTML to PNG by reading ImageSaveOptions from a JSON configuration file and applying them.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string jsonPath = "options.json";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose!</h1></body></html>");
            }

            // Create a default JSON configuration if it does not exist
            if (!System.IO.File.Exists(jsonPath))
            {
                string defaultJson = @"{
  ""HorizontalResolution"": 300,
  ""VerticalResolution"": 300,
  ""UseAntialiasing"": true,
  ""BackgroundColor"": ""White""
}";
                System.IO.File.WriteAllText(jsonPath, defaultJson);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Initialize ImageSaveOptions for PNG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Read and apply options from JSON configuration
            string jsonContent = System.IO.File.ReadAllText(jsonPath);
            using (var jsonDoc = System.Text.Json.JsonDocument.Parse(jsonContent))
            {
                var root = jsonDoc.RootElement;

                if (root.TryGetProperty("HorizontalResolution", out var horResElem) && horResElem.TryGetInt32(out int horRes))
                {
                    options.HorizontalResolution = horRes;
                }

                if (root.TryGetProperty("VerticalResolution", out var verResElem) && verResElem.TryGetInt32(out int verRes))
                {
                    options.VerticalResolution = verRes;
                }

                if (root.TryGetProperty("UseAntialiasing", out var aaElem))
                {
                    if (aaElem.ValueKind == System.Text.Json.JsonValueKind.True)
                        options.UseAntialiasing = true;
                    else if (aaElem.ValueKind == System.Text.Json.JsonValueKind.False)
                        options.UseAntialiasing = false;
                }

                if (root.TryGetProperty("BackgroundColor", out var bgElem) && bgElem.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    string colorName = bgElem.GetString();
                    var color = System.Drawing.Color.FromName(colorName);
                    if (color.IsKnownColor || color.IsNamedColor)
                    {
                        options.BackgroundColor = color;
                    }
                }
            }

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}