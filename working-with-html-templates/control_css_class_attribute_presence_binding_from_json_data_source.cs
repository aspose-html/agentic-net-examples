// Control the presence of a CSS class attribute by binding its value from the JSON data source.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div id=\"target\">Hello</div></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);
            string json = "{\"addClass\": true}";
            bool addClass = System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("addClass").GetBoolean();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            if (addClass)
            {
                Aspose.Html.Dom.Element element = document.QuerySelector("#target");
                if (element != null)
                {
                    element.SetAttribute("class", "myClass");
                }
            }
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}