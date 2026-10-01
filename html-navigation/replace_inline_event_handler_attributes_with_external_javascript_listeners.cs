// Replace all inline event handler attributes (e.g., onclick) with external JavaScript listeners.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><button onclick=\"alert('Clicked!')\">Click me</button></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            var elements = document.QuerySelectorAll("[onclick]");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)elements[i];
                string val = el.GetAttribute("onclick");
                if (!string.IsNullOrEmpty(val))
                {
                    el.RemoveAttribute("onclick");
                }
            }
            document.Save(outputPath);
            System.Console.WriteLine("Inline event handlers removed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}